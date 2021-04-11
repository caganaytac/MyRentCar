using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserProfilePhotoService
    {
        IDataResult<List<UserProfilePhoto>> GetAll();
        IDataResult<UserProfilePhoto> GetById(int id);
        IDataResult<UserProfilePhoto> GetByUserId(int userId);
        IResult Add(IFormFile file, UserProfilePhoto userProfilePhoto);
        IResult Update(IFormFile file, UserProfilePhoto userProfilePhoto);
        IResult Delete(UserProfilePhoto userProfilePhoto);


    }
}
