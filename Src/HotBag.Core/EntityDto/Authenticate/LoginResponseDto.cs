namespace HotBag.Core.EntityDto.Authenticate
{
    public class LoginResponseDto
    {
        public bool IsLoginSuccess { get; set; }
        public string Token { get; set; }
        public string EncryptedToken { get; set; }
        public int Expires { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
