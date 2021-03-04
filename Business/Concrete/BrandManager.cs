using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll().ToList(), "Brands listed!");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id), "Got Brand you want.");
        }

        public IResult AddBrand(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandLimitExceeded(), CheckIfBrandAlreadyExists(brand.BrandName));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private IResult CheckIfBrandLimitExceeded()
        {
            var result = _brandDal.GetAll().Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.BrandCountLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandAlreadyExists(string name)
        {
            var result = _brandDal.GetAll(b =>b.BrandName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
