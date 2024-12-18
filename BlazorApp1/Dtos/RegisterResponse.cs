using AnnouncementsAPI.Enums;

namespace AnnouncementsAPI.Dtos
{
    public class RegisterResponse
    {
        public RegisterResponseEnum Response { get; set; }
        public List<string>? Message { get; set; }
    }
}
