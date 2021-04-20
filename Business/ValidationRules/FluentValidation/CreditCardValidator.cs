using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator: AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(p => p.CardHolderName).NotNull().WithMessage(Messages.CardHolderNameNotNull);

            RuleFor(p => p.ExpMonth).NotNull().WithMessage(Messages.ExpMonthNotNull);
            RuleFor(p => p.ExpMonth).InclusiveBetween(01, 12).WithMessage(Messages.ExpMonthInclusiveBetween);

            RuleFor(p => p.ExpYear).NotNull().WithMessage(Messages.ExpYearhNotNull);
            RuleFor(p => p.ExpYear).InclusiveBetween(21,50).WithMessage(Messages.ExpYearInclusiveBetween);

            RuleFor(p => p.Cvv).NotNull().WithMessage(Messages.CvcNotNull);
            RuleFor(p => p.Cvv).Length(3).WithMessage(Messages.CvcLength3);

            RuleFor(p => p.CardNumber).NotNull().WithMessage(Messages.CardNumberNotNull);
            RuleFor(p => p.CardNumber).Length(16).WithMessage(Messages.CardNumberLength16);
        }

    }
}
