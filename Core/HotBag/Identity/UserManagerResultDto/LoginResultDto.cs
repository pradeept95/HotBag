using HotBag.AppUser;

namespace HotBag.Identity.UserManagerResultDto
{
    public class LoginResultDto
    {
        public bool IsLoginSuccess { get; set; }
        public string  LoginErrorMessage { get; set; } 
        public HotBagUser User { get; set; } 
    }
}
