namespace VueAppTsApi.Core.DTOs
{
    public class AuthResponseDTO
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public UserDTO User { get; set; }
    }
}