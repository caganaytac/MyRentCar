using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetCarsByCarId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), "Found you choice car.");
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id).ToList(), "Got you choice brand cars.");
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id).ToList());
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            AddCar(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            AddCar(car);
            return null;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidation))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExists(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [SecuredOperation("car.update, admin")]
        [ValidationAspect(typeof(CarValidation))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.delete, admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Car deleted!");

        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
