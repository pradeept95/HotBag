
using HotBag.AppUser;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Services.Identity
{
    public interface IUserManager
    {
        Task<bool> GetLoginAsync(string userNameOrEmail);
        Task<bool> ChangeUserPasswordAsync(string oldPassword, string newPassword);
        Task<bool> ChangeUserPasswordAsync(HotBagUser user, string newPassword);



        Task<string> GetResetUserPasswordTokenAsync(HotBagUser user);
        Task<string> GetResetUserPasswordTokenAsync(string emailAddress);
        Task<bool> ResetUserPasswordAsync(string token, string newPassword);

        Task<HotBagUser> GetUserByEmailAsync(string emailAddress); 
        Task<HotBagUser> GetUserByUsernameAsync(string username);
        Task<HotBagUser> GetUserByUsernameOrEmailAsync(string usernameOrEmailAddress); 
    }
}
