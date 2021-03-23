using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarBaseContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (CarBaseContext context = new CarBaseContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    select new CarDetailsDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        BrandId = b.BrandId,
                        CarId = c.CarId,
                        ColorId = c.ColorId,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        ImagePath = (from carImage in context.CarImages where carImage.CarId == c.CarId select carImage.ImagePath).FirstOrDefault(),
                        Status =  !(from rental in context.Rentals where rental.CarId == c.CarId select rental.ReturnDate == null).Any()

                    };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

    }
}


