using LoginPage.Models;

namespace LoginPage.AuthLoginRepositories
{
    public interface IAuthLoginRepository
    {
        Task<IEnumerable<UserLogin>> GetUser();
        Task<UserLogin> AuthenticateUser(string username, string passcode); 
    }
}
