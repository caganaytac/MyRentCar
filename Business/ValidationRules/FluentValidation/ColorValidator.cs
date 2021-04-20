using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).NotEmpty().WithMessage(Messages.ColorNameNotEmpty);
            RuleFor(p => p.ColorName).MinimumLength(2).WithMessage(Messages.ColorLengthMin2);

        }
    }
}
