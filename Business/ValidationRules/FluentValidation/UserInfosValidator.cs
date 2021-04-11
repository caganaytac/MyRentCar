using System;
using System.Collections.Generic;
using System.Text;
using Business.Contants;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserInfosValidator:AbstractValidator<User>
    {
        public UserInfosValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(p => p.Email).EmailAddress().WithMessage(Messages.IsNotEmail);

            RuleFor(p => p.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty);
            RuleFor(p => p.FirstName).Length(2, 10).WithMessage(Messages.FirstNameLength);

            RuleFor(p => p.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
            RuleFor(p => p.LastName).Length(2, 10).WithMessage(Messages.LastNameLength);
        }
    }
}
