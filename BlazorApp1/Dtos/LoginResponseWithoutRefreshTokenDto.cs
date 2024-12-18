using AnnouncementsAPI.Enums;

namespace AnnouncementsAPI.Dtos
{
    public class LoginResponseWithoutRefreshTokenDto
    {
        public LoginResponseEnum Response { get; set; }
        public string? Token { get; set; }
    }
}
