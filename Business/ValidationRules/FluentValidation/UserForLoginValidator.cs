using Business.Constants;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage(Messages.PasswordNotNull); ;
            RuleFor(p => p.Email).EmailAddress().WithMessage(Messages.IsNotEmail);

            RuleFor(p => p.Password).NotNull().WithMessage(Messages.PasswordNotNull);
        }
    }
}