using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.BrandName).NotEmpty().WithMessage(Messages.BrandNameNotEmpty);
            RuleFor(p => p.BrandName).MinimumLength(2).WithMessage(Messages.BrandLengthMin2);

        }
    }
}
