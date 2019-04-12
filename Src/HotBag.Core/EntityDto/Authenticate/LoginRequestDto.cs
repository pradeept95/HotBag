using System.ComponentModel.DataAnnotations;

namespace HotBag.Core.EntityDto.Authenticate
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Username Or Email is required")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
