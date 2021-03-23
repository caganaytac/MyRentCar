using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailsDto>> GetAllCustomerDetails();
        IDataResult<Customer> GetByCustomerId(int id);
        IResult AddCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
    }
}
