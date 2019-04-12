﻿using System;
using System.Threading.Tasks;
using HotBag.AppUser;
using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.Identity.UserManagerResultDto;
using HotBag.Security.PasswordHasher;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFrameworkCore.Services.Identity
{
    public class UserManager : IUserManager, ITransientDependencies
    {
        private readonly IEFRepository<HotBagUser, Guid> _userRepository;
        public UserManager(IEFRepository<HotBagUser, Guid> userRepository)
        {
            _userRepository = userRepository;
        } 

        public Task<bool> AddUserPermissions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserPasswordAsync(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserPasswordAsync(HotBagUser user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResultDto> GetLoginAsync(string userNameOrEmail, string password)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x =>
                 x.Email.ToLower() == userNameOrEmail.ToLower()
                 || x.Username.ToLower() == userNameOrEmail.ToLower()
            );

            return await GetLoginAsync(user, password);
        }

        public async Task<LoginResultDto> GetLoginAsync(HotBagUser user, string password)
        {
            var result = new LoginResultDto
            {
                IsLoginSuccess = false,
                LoginErrorMessage = "Unknown Error",
                User = null
            }; 

            if (user == null)
            {
                result.LoginErrorMessage = "Username or Password is invalid";
                return result;
            } 

            if (!PasswordHasher.VerifyHashedPassword(user.HashedPassword, password))
            {
                result.LoginErrorMessage = "Username or Password is invalid";
                return result;
            }

            var userStatusResult = CheckUserStatus(user);
            if (userStatusResult.isSuccess)
            {
                result.IsLoginSuccess = true;
                result.LoginErrorMessage = string.Empty;
                result.User = user;
                return result;
            }
            else
            {
                result.IsLoginSuccess = false;
                result.LoginErrorMessage = userStatusResult.errorMessage;
                result.User = null;
                return result;
            }
        }

        private (bool isSuccess, string errorMessage) CheckUserStatus(HotBagUser user)
        {
            var result = (false, "Unable to find result");
            switch (user.Status)
            {
                case UserStatus.Active:
                    result = (true, "User status is active");
                    break;
                case UserStatus.InActive:
                    result = (false, "User is not Active, Please contact with admin");
                    break;
                case UserStatus.EmailNotConfirmed:
                    result = (false, "Email not Confirmed, Please confirm your email by clicking link on email");
                    break;
                case UserStatus.Suspended:
                    result = (false, "User is suspended");
                    break;
                case UserStatus.PasswordExpired:
                    result = (false, "Password is expired, Please reset your password");
                    break;
                case UserStatus.PasswordNotCreated:
                    result = (false, "Password Not Created");
                    break;
                default:
                    break;
            }

            return result;
        }

        public Task<string> GetResetUserPasswordTokenAsync(HotBagUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetResetUserPasswordTokenAsync(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<HotBagUser> GetUserByEmailAsync(string emailAddress)
        {
            return await _userRepository.GetAll().FirstOrDefaultAsync(x =>
              x.Email.ToLower() == emailAddress.ToLower()
          );
        }

        public async Task<HotBagUser> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetAll().FirstOrDefaultAsync(x =>
               x.Username.ToLower() == username.ToLower()
           );
        }

        public async Task<HotBagUser> GetUserByUsernameOrEmailAsync(string usernameOrEmailAddress)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x =>
                x.Email.ToLower() == usernameOrEmailAddress.ToLower()
                || x.Username.ToLower() == usernameOrEmailAddress.ToLower()
           );
            return user;
        }

        public Task<bool> RemoveAllPermissions(HotBagUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllPermissions(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetUserPasswordAsync(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePasswordAsync(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePasswordAsync(HotBagUser user, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
