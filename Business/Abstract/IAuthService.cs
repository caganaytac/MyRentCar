using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult ChangePassword(UserChangePasswordDto userChangePasswordDto);
    }
}
