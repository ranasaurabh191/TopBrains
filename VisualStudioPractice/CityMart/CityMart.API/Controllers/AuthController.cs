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

        [HttpGet("test")]
        public IActionResult Test()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
                return Unauthorized(new { message = "You must be logged in to access this." });

            return Ok("You are authorized");
        }

        [HttpGet("testRole")]
        public IActionResult TestRole()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
                return Unauthorized(new { message = "You must be logged in." });

            if (!User.IsInRole("Admin"))
                return StatusCode(403, new { message = "You need Admin role to access this." });

            return Ok("You are authorized as admin");
        }
    }
}
