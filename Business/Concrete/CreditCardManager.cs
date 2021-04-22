using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;
        private readonly IUserService _userService;

        public CreditCardManager(ICreditCardDal creditCardDal, IUserService userService)
        {
            _creditCardDal = creditCardDal;
            _userService = userService;
        }

        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CreditCard>> GetByUserId(int id)
        {
            IDataResult<List<CreditCard>> result = BusinessRules.Run(IsUserExists(id));
            if (result != null)
            {
                return result;
            }
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(p=>p.UserId == id));
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult AddCreditCard(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(IsUserExists(creditCard.UserId));
            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult UpdateCreditCard(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(IsUserExists(creditCard.UserId));
            if (result != null)
            {
                return result;
            }
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult DeleteCreditCard(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        //Business Codes

        private IDataResult<List<CreditCard>> IsUserExists(int id)
        {
            if (_userService.GetByUserId(id).Data == null)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.UserNotFound);
            }
            return new SuccessDataResult<List<CreditCard>>();
        }
    }
}
