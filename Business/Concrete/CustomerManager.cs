using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private IUserService _userService;
        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CustomerDetailsDto>> GetAllCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetCustomerDetails());
        }

        [CacheAspect]
        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p =>p.UserId == id));
        }
        
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult AddCustomer(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfTheCustomerIsAUser(customer.UserId));
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);

        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);

        }
        
        private IResult CheckIfTheCustomerIsAUser(int id)
        {
            var result = _userService.GetByUserId(id);
            if (!result.Success)
            {
                return new ErrorResult(Messages.CustomerIsNotUser);
            }
            return new SuccessResult();
        }
    }
}
