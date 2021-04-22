using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string mail)
        {
           return new SuccessDataResult<User>(_userDal.Get(p => p.Email == mail));
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [ValidationAspect(typeof(UserInfosValidator))]
        public IResult UpdateUserInfos(User user)
        {
            var userToUpdate = GetByUserId(user.Id).Data;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            UpdateUser(userToUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
