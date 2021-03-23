using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
   public class PaymentDto : IDto 
   {
       public Payment Payment { get; set; }
       public Rental Rental { get; set; }
    }
}
