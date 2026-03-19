using Microsoft.AspNetCore.Identity;

namespace CityMart.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}