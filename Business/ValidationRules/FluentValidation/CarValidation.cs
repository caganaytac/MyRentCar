using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Daily Price does not have to be 0!");
            RuleFor(p => p.CarName).MinimumLength(2).WithMessage("Car Name must have a minimum of 2 characters!");
        }

      
    }
}
