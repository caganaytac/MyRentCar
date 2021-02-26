using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IResult Add(CarImage carImage, string extension)
        {
            var result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var addedCarImage = CreatedFile(carImage, extension).Data;
            _carImageDal.Add(addedCarImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Update(CarImage carImage)
        {
            var carImageUpdate = UpdatedFile(carImage).Data;
            _carImageDal.Update(carImageUpdate);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        //BusinessRules
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage>{new CarImage{CarId = id, ImagePath = path, Date = DateTime.Now}};
            }

            return _carImageDal.GetAll(p => p.CarId == id);
        }

        private IDataResult<CarImage> CreatedFile(CarImage carImage, string extension)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            var creatingUniqueFileName = Guid.NewGuid().ToString("N")
                                         + "_" + DateTime.Now.Month + "_"
                                         + DateTime.Now.Day + "_"
                                         + DateTime.Now.Year + extension;

            string source = Path.Combine(carImage.ImagePath);
            string result = $@"{path}\{creatingUniqueFileName}";

            try
            {
                File.Move(source, path + @"\" + creatingUniqueFileName);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CarImage>(e.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, Date = DateTime.Now, ImagePath = result }, Messages.CarImageAdded);
        }

        private IDataResult<CarImage> UpdatedFile(CarImage carImage)
        {
            var creatingUniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" +
                                         DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";
            
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{creatingUniqueFileName}";
            
            File.Copy(carImage.ImagePath, path + "\\" + creatingUniqueFileName);
            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage{Id = carImage.Id, CarId = carImage.CarId, Date = DateTime.Now, ImagePath = result});
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }
            return new SuccessResult();
        }
    }
}
