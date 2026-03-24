namespace JwtTokenDemo.AuthenticationService
{
    public interface IAuthService
    {
        string GenerateToken(string username);
    }
}
