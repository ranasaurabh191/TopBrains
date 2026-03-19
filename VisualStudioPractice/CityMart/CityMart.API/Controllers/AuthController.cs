using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityMart.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            return Ok(new
            {
                token = token
            });
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("You are authorized");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("testRole")]
        public IActionResult TestRole()
        {
            return Ok("You are authorized");
        }
    }
}
