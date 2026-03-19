using CityMart.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMart.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
    }
}
