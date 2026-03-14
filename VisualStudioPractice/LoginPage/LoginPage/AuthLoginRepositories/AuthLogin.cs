using LoginPage.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.AuthLoginRepositories
{
    public class AuthLogin : IAuthLoginRepository
    {
        private readonly LoginDbContext _context;
        public AuthLogin(LoginDbContext context)
        {
            _context = context;
        }

        public async Task<UserLogin> AuthenticateUser(string username, string passcode)
        {
            var succeeded = await _context.UserLogins.FirstOrDefaultAsync(u => u.UserName == username && u.passCode == passcode);
            return succeeded;
        }
        public async Task<IEnumerable<UserLogin>> GetUser()
        {
            return await _context.UserLogins.ToListAsync();
        }
    }
}