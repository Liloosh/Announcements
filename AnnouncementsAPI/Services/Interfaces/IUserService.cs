using AnnouncementsAPI.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AnnouncementsAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResponseDto> Register(RegisterRequestDto dto);
        Task<LoginResponseDto> Login(LoginRequestDto dto);
        Task<string> GenerateJwtToken(IdentityUser user);
        Task<RefreshTokenDto?> RefreshToken(string refreshToken);
    }
}
