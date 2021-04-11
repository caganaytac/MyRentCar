using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
   public class CarUpdateDto : IDto
    {
        public Car Car { get; set; }
        public IFormFile Image { get; set; }
    }
}
