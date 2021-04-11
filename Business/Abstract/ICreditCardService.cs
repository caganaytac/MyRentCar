using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int id);
        IDataResult<List<CreditCard>> GetByUserId(int id);
        IResult AddCreditCard(CreditCard creditCard);
        IResult UpdateCreditCard(CreditCard creditCard);
        IResult DeleteCreditCard(CreditCard creditCard);
    }
}
