﻿namespace AnnouncementsAPI.Dtos
{
    public class RegisterRequestDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}