using System;
using System.Collections.Generic;
using System.Linq;
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
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        private readonly IUserCreditScoreService _userCreditScoreService;
        private readonly IPaymentService _paymentService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService, IUserCreditScoreService userCreditScoreService, IPaymentService paymentService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
            _userCreditScoreService = userCreditScoreService;
            _paymentService = paymentService;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalsDto(int carId)
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails(x => x.CarId == carId));
        }
        public IDataResult<List<RentalDetailsDto>> GetAllRentalsDto()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }
        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult AddRental(Rental rental, Payment payment)
        {
            IResult result = BusinessRules.Run(IsCarAvailable(rental), IsCreditScoreEnough(rental.CustomerId, rental.CarId));
            if (result != null)
            {
                return result;
            }

            var isPaymented = _paymentService.Add(payment);
            if (!isPaymented.Success)
            {
                return new ErrorResult(Messages.PaymentFailed);
            }
            _rentalDal.Add(rental);

            var customer = _customerService.GetByCustomerId(rental.CustomerId).Data;
            var userCreditScore = _userCreditScoreService.GetByUserId(customer.UserId).Data;

            userCreditScore.CreditScore += 50;
            if (userCreditScore.CreditScore > 1999)
            {
                userCreditScore.CreditScore = 1999;
            }
            _userCreditScoreService.Update(userCreditScore);

            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult UpdateRental(Rental rental)
        {
            IResult result = BusinessRules.Run(IsRentalExist(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeleteRental(Rental rental)
        {
            IResult result = BusinessRules.Run(IsRentalExist(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //Business Codes
        private IResult IsCarAvailable(Rental rental)
        {
            var result = _rentalDal.Get(p =>
                p.CarId == rental.CarId && (p.ReturnDate == null || p.ReturnDate >= DateTime.UtcNow));
            if (result != null)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            return new SuccessResult();
        }

        private IResult IsRentalExist(int carId)
        {
            var result = _rentalDal.GetRentalDetails(p => p.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RentalIsNotExist);
            }
            return new SuccessResult();
        }

        private IResult IsCreditScoreEnough(int customerId, int carId)
        {
            var carCreditScore = _carService.GetCarsByCarId(carId).Data.CreditScore;
            int userId = _customerService.GetByCustomerId(customerId).Data.UserId;
            var creditScore = _userCreditScoreService.GetByUserId(userId).Data.CreditScore;
            if (carCreditScore > creditScore)
            {
                return new ErrorResult(Messages.CreditScoreInsufficient);
            }
            return new SuccessResult();
        }
    }
}
