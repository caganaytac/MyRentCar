using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserProfilePhotoValidator:AbstractValidator<UserProfilePhoto>
    {
        public UserProfilePhotoValidator()
        {
            RuleFor(p => p.UserId).NotNull();
        }
    }
}
