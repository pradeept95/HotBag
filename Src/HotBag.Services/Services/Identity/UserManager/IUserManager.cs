
using HotBag.AppUser;
using HotBag.Identity.UserManagerResultDto;
using System;
using System.Threading.Tasks;

namespace HotBag.Services.Identity
{
    public interface IUserManager
    {
        Task<LoginResultDto> GetLoginAsync(string userNameOrEmail, string password);
        Task<LoginResultDto> GetLoginAsync(HotBagUser user, string password);

        Task<string> GetAllPermissions(HotBagUser user);

        Task<bool> CreatePasswordAsync(string oldPassword, string newPassword);
        Task<bool> CreatePasswordAsync(HotBagUser user, string newPassword);

        Task<bool> ChangeUserPasswordAsync(string oldPassword, string newPassword);
        Task<bool> ChangeUserPasswordAsync(HotBagUser user, string newPassword);
         
        Task<string> GetResetUserPasswordTokenAsync(HotBagUser user);
        Task<string> GetResetUserPasswordTokenAsync(string emailAddress);
        Task<bool> ResetUserPasswordAsync(string token, string newPassword);

        Task<HotBagUser> GetUserByEmailAsync(string emailAddress); 
        Task<HotBagUser> GetUserByUsernameAsync(string username);
        Task<HotBagUser> GetUserByUsernameOrEmailAsync(string usernameOrEmailAddress);

        Task<bool> AddUserPermissions();
        Task<bool> RemoveAllPermissions(HotBagUser user);
        Task<bool> RemoveAllPermissions(Guid userId);
    }
}
