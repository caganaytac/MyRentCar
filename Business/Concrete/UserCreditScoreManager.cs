using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserCreditScoreManager : IUserCreditScoreService
    {
        private readonly IUserCreditScoreDal _userCreditScoreDal;
        private readonly IUserService _userService;

        public UserCreditScoreManager(IUserCreditScoreDal userCreditScoreDal, IUserService userService)
        {
            _userCreditScoreDal = userCreditScoreDal;
            _userService = userService;
        }

        public IDataResult<List<UserCreditScore>> GetAll()
        { 
            return new SuccessDataResult<List<UserCreditScore>>(_userCreditScoreDal.GetAll());
        }

        public IDataResult<UserCreditScore> GetById(int id)
        {
            return new SuccessDataResult<UserCreditScore>(_userCreditScoreDal.Get(p=>p.Id == id));
        }

        public IDataResult<UserCreditScore> GetByUserId(int id)
        {
            return new SuccessDataResult<UserCreditScore>(_userCreditScoreDal.Get(p => p.UserId == id));
        }

        public IResult Add(UserCreditScore userCreditScore)
        {
            IResult result = BusinessRules.Run(IsUserExists(userCreditScore.UserId));
            if (result != null)
            {
                return result;
            }

            _userCreditScoreDal.Add(userCreditScore);
            return new SuccessResult();
        }

        public IResult Update(UserCreditScore userCreditScore)
        {
            _userCreditScoreDal.Update(userCreditScore);
            return new SuccessResult();
        }

        public IResult Delete(UserCreditScore userCreditScore)
        {
            _userCreditScoreDal.Delete(userCreditScore);
            return new SuccessResult();
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
