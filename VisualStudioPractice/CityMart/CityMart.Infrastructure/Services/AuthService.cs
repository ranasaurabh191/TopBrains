using System.Linq;
using Microsoft.AspNetCore.Identity;
using CityMart.Domain.Identity;
using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;

namespace CityMart.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtService _jwtService;

        public AuthService(UserManager<ApplicationUser> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterAsync(RegisterDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                return "Invalid data";

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return string.Join(", ", result.Errors.Select(e => e.Description));

            await _userManager.AddToRoleAsync(user, "Customer");

            return "Registration Successful";
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                return "Invalid credentials";

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return "User not found";

            var isValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isValid)
                return "Invalid password";

            var roles = await _userManager.GetRolesAsync(user);

            var token = _jwtService.GenerateToken(user, roles);

            return token;
        }
    }
}
