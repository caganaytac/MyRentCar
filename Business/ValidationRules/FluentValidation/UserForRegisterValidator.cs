using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(p => p.Email).EmailAddress().WithMessage(Messages.IsNotEmail); 

            RuleFor(p => p.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty); 
            RuleFor(p => p.FirstName).Length(2, 10).WithMessage(Messages.FirstNameLength); 

            RuleFor(p => p.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
            RuleFor(p => p.LastName).Length(2, 10).WithMessage(Messages.LastNameLength); 

            RuleFor(p => p.Password).NotNull().WithMessage(Messages.PasswordNotNull); 
            RuleFor(p => p.Password).Length(5, 50).WithMessage(Messages.PasswordLength);
        }
    }
}
