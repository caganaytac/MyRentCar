using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CarId).NotNull();
            RuleFor(p => p.CustomerId).NotNull();
            RuleFor(p => p.RentDate).NotNull();

        }
    }
}
