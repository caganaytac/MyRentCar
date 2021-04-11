using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByCarId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarsDetailsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<List<CarDetailsDto>> GetCarsDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId);
        IResult AddTransactionalTest(Car car,IFormFile image);
        IResult AddCar(Car car, IFormFile image);
        IResult UpdateCar(Car car, IFormFile image);
        IResult DeleteCar(Car car);
        IDataResult<CarDetailsDto> GetCarsDetailsByCarId( int carId);
        IResult UpdateCarWithOutImage(Car car);
    }
}
