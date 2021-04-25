using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserCreditScoreService _userCreditScoreService;
        private readonly ICustomerService _customerService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService,
            ITokenHelper tokenHelper,
            IUserCreditScoreService userCreditScoreService,
            ICustomerService customerService,
            IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userCreditScoreService = userCreditScoreService;
            _customerService = customerService;
            _userOperationClaimService = userOperationClaimService;
        }

        [ValidationAspect(typeof(UserForRegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            if (_userService.GetByMail(userForRegisterDto.Email).Data != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.AddUser(user);

            var userCreditScore = new UserCreditScore { UserId = user.Id, CreditScore = 400 };
            _userCreditScoreService.Add(userCreditScore);

            var customer = new Customer { UserId = user.Id, CompanyName = $"{user.FirstName} {user.LastName}" };
            _customerService.AddCustomer(customer);

            _userOperationClaimService.AddUserClaim(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        [ValidationAspect(typeof(UserForLoginValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            IDataResult<User> result = BusinessRules.Run(VerifyPasswordHashing(userForLoginDto.Password,
                userToCheck.PasswordHash, userToCheck.PasswordSalt));
            if (result != null)
            {
                return result;
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfullLogin);
        }

        public IResult ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            var userToCheck = _userService.GetByUserId(userChangePasswordDto.UserId).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            IDataResult<User> result = BusinessRules.Run(VerifyPasswordHashing(userChangePasswordDto.OldPassword,
                userToCheck.PasswordHash, userToCheck.PasswordSalt));

            if (result != null)
            {
                return result;
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userChangePasswordDto.NewPassword, out passwordHash, out passwordSalt);

            userToCheck.PasswordHash = passwordHash;
            userToCheck.PasswordSalt = passwordSalt;

            _userService.UpdateUser(userToCheck);
            return new SuccessResult(Messages.PasswordChanged);
        }

        private IDataResult<AccessToken> MyCreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        //Business
        private IDataResult<User> VerifyPasswordHashing(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHashing(password, passwordHash, passwordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>();
        }
    }
}
