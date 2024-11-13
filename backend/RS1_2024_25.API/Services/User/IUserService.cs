namespace RS1_2024_25.API.Services.User
{
    public interface IUserService
    {
        Task<string> GenerateRefreshToken(string username);
        Task<string> Authenticate(string username, string password);
        Task<string> RefreshToken(string token);

    }

}
