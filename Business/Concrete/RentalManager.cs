using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Aspects.Autofac.Caching;
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
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
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

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult AddRental(Rental rental)
        {
            IResult result = BusinessRules.Run(WillLeasedCarAvailable(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

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

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(p => p.CarId == carId && p.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.CarCanNotBeRented);
            }
            return new SuccessResult();
        }
        private IResult WillLeasedCarAvailable(int carId)
        {
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) != null)
                return new ErrorResult(Messages.CarNotAvaible);
            else
                return new SuccessResult();
        }
        public IResult IsRentalExist(int carId)
        {
            var result = _rentalDal.GetRentalDetails(p => p.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RentalIsNotExist);
            }
            return new SuccessResult();
        }
    }
}
