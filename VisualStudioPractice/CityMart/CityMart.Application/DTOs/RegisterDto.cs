using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CityMart.Application.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string? FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string? Email { get; set; } = null;

        [Required] 
        [MinLength(6)]
        public string? Password { get; set; } = string.Empty;
    }
}
