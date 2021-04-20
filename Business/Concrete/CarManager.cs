using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetCarsByCarId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id).ToList());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId).ToList());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p => p.ColorId == id));
        }
        
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<CarDetailsDto> GetCarsDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarDetail(p => p.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p=> p.BrandId == brandId && p.ColorId == colorId));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car, IFormFile image)
        {
            AddCar(car, image);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            AddCar(car, image);
            return null;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car, IFormFile image)
        {

            _carDal.Add(car);
            _carImageService.Add(image, new CarImage { CarId = car.CarId });
            return new SuccessResult(Messages.CarAdded);

        }

        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCarWithOutImage(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCar(Car car, IFormFile image)
        {
            var carImages = _carImageService.GetAllByCarId(car.CarId).Data;

            foreach(var carImage in carImages)
            {
                _carImageService.Update(image, carImage);
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteCar(Car car)
        {
            var carImage = _carImageService.GetByCarId(car.CarId).Data;
            if (carImage != null)
            {
                _carImageService.Delete(carImage);
            }
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }
    }
}
