using System;
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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarBaseContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarBaseContext context = new CarBaseContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailsDto
                    {
                        FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, CompanyName = c.CompanyName, customerId = c.CustomerId
                    };
                return result.ToList();
            }
        }
    }
}
