using AnnouncementsAPI.Enums;
using Microsoft.AspNetCore.Identity;

namespace AnnouncementsAPI.Dtos
{
    public class RegisterResponseDto
    {
        public RegisterResponseEnum Response { get; set; }
        public IdentityResult? Result { get; set; }
    }
}
