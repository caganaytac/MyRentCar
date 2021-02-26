using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IResult Add(CarImage carImage, string extension); 
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);


    }
}
