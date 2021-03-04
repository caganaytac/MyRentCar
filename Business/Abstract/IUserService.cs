using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string mail); IResult UpdateUser(User user);
        IResult AddUser(User user);
        IResult DeleteUser(User user);
    }
}
