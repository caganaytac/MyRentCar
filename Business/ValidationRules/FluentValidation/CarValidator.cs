using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage(Messages.DailyPriceCanNot0);
            RuleFor(p => p.CarName).MinimumLength(2).WithMessage(Messages.MinCarName);
            RuleFor(p => p.CreditScore).InclusiveBetween(0, 1999);
        }

      
    }
}
