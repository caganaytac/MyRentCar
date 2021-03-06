﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarBaseContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<RentalDetailsDto, bool>> filter = null)
        {
            using (CarBaseContext context = new CarBaseContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars on re.CarId equals ca.CarId
                             join cus in context.Customers on re.CustomerId equals cus.CustomerId
                             join u in context.Users on cus.UserId equals u.Id
                             join b in context.Brands on ca.BrandId equals b.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new RentalDetailsDto
                             {
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 RenterName = u.FirstName,
                                 RenterSurname = u.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 RentalId = re.Id,
                                 CustomerId = re.CustomerId,
                                 CarId = re.CarId,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 CarDescription = ca.Description
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
