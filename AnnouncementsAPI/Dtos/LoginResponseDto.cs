using AnnouncementsAPI.Enums;

namespace AnnouncementsAPI.Dtos
{
    public class LoginResponseDto
    {
        public LoginResponseEnum Response { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
