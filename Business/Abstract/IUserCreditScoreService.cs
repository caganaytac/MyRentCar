using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IUserCreditScoreService
   {
       IDataResult<List<UserCreditScore>> GetAll();
       IDataResult<UserCreditScore> GetById(int id);
       IDataResult<UserCreditScore> GetByUserId(int id);
       IResult Add(UserCreditScore userCreditScore);
       IResult Update(UserCreditScore userCreditScore);
       IResult Delete(UserCreditScore userCreditScore);
    }
}
