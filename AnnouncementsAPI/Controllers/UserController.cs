﻿using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var result = await _userService.Register(dto);

            var response = new RegisterResponse()
            {
                Response = result.Response,
                Message = new List<string>()
            };

            if (result.Response == RegisterResponseEnum.UserNameIsExist)
            {
                response.Message.Add("UserName is already exist!");
                return BadRequest(response);
            }
            else if (result.Response == RegisterResponseEnum.EmailIsExist)
            {
                response.Message.Add("Email is already exist!");
                return BadRequest(response);
            }
            else if (result.Response == RegisterResponseEnum.Ok)
            {
                return Ok(response);
            }
            else
            {
                foreach (var item in result.Result!.Errors.ToList())
                {
                    response.Message.Add(item.Description);
                }
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _userService.Login(dto);

            if (result.Response == LoginResponseEnum.EmailOrPasswordIsNotCorrect)
            {
                return BadRequest("Email or Password is not correct");
            }
            else if (result.Response == LoginResponseEnum.UserIsLockedOut)
            {
                return BadRequest("User is locked out!!");
            }

            var cookieOptions = new CookieOptions
            {
                Domain = "localhost",
                Path = "/",
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(1),
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("RefreshToken", result.RefreshToken!);

            var response = new LoginResponseWithoutRefreshTokenDto()
            {
                Response = result.Response,
                Token = result.Token,
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];
            var response = new RefreshTokenResponse();
            if (refreshToken == null)
            {
                response.Message = "RefreshToken expired or don`t exist";
                return Unauthorized(response);
            }

            var newRefreshToken = await _userService.RefreshToken(refreshToken);

            if (newRefreshToken == null)
            {
                response.Message = "RefreshToken expired or don`t exist";
                return Unauthorized(response);
            }

            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),
                Secure = true
            };
            Response.Cookies.Append("RefreshToken", newRefreshToken.RefreshToken!, cookieOptions);

            response.Token = newRefreshToken.Token;
            return Ok(response);
        }
    }
}
