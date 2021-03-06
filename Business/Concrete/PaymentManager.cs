﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
   public class PaymentManager : IPaymentService
   {
        public IResult Add(Payment payment)
        {
            return new SuccessResult(Messages.PaymentCompleted);
        }
   }
}
