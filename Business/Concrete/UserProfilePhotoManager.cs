using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserProfilePhotoManager : IUserProfilePhotoService
    {
        private readonly IUserProfilePhotoDal _userProfilePhotoDal;
        private readonly IUserService _userService;

        public UserProfilePhotoManager(IUserProfilePhotoDal userProfilePhotoDal, IUserService userService)
        {
            _userProfilePhotoDal = userProfilePhotoDal;
            _userService = userService;
        }

        [CacheAspect]
        public IDataResult<List<UserProfilePhoto>> GetAll()
        {
            return new SuccessDataResult<List<UserProfilePhoto>>(_userProfilePhotoDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<UserProfilePhoto> GetById(int id)
        {
            return new SuccessDataResult<UserProfilePhoto>(_userProfilePhotoDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<UserProfilePhoto> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserProfilePhoto>(_userProfilePhotoDal.Get(p => p.UserId == userId));
        }

        [ValidationAspect(typeof(UserProfilePhotoValidator))]
        [CacheRemoveAspect("IUserProfileService.Get")]
        public IResult Add(IFormFile file, UserProfilePhoto userProfilePhoto)
        {

            var result = BusinessRules.Run(IsUserExists(userProfilePhoto.UserId));
            if (result != null)
            {
                return result;
            }

            userProfilePhoto.Date = DateTime.UtcNow;
            userProfilePhoto.ImagePath = FileHelper.Add(file);
            _userProfilePhotoDal.Add(userProfilePhoto);
            return new SuccessResult(Messages.UserProfilePhotoAdded);
        }

        [ValidationAspect(typeof(UserProfilePhotoValidator))]
        [CacheRemoveAspect("IUserProfileService.Get")]
        public IResult Update(IFormFile file, UserProfilePhoto userProfilePhoto)
        {
            userProfilePhoto.Date = DateTime.UtcNow;
            userProfilePhoto.ImagePath = FileHelper.Update(_userProfilePhotoDal.Get(p => p.Id == userProfilePhoto.Id).ImagePath, file);
            _userProfilePhotoDal.Update(userProfilePhoto);
            return new SuccessResult(Messages.UserProfilePhotoUpdated);
        }

        [CacheRemoveAspect("IUserProfileService.Get")]
        public IResult Delete(UserProfilePhoto userProfilePhoto)
        {
            FileHelper.Delete(userProfilePhoto.ImagePath);
            _userProfilePhotoDal.Delete(userProfilePhoto);
            return new SuccessResult(Messages.UserProfilePhotoDeleted);
        }

        //Business Codes
        private IResult IsUserExists(int id)
        {
            if (!_userService.GetByUserId(id).Success)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }
    }
}