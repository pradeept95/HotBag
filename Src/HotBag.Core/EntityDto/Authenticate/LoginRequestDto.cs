namespace HotBag.Core.EntityDto.Authenticate
{
    public class LoginRequestDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
