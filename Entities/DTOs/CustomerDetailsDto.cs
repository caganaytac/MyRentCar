using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailsDto : IDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
