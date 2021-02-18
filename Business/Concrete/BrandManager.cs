using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
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
          return new SuccessDataResult<List<Brand>>(_brandDal.GetAll().ToList(),"Brands listed!");
       }

       public IDataResult<Brand> GetById(int id)
       {
           return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id),true,"Got Brand you want.");
       }

        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
