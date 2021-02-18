﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

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
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == id));
        }

        [ValidationAspect(typeof(UserValidation))]
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User added successfully.");

        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User updated successfully.");
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("User deleted successfully.");
        }
    }
}