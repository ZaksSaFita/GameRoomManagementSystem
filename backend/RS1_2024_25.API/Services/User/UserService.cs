using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helpers;
using RS1_2024_25.API.Services.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly JWTSettings _jwtSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(ApplicationDbContext context, IOptions<JWTSettings> jwtSettings, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings), "JWTSettings cannot be null");
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor), "HttpContextAccessor cannot be null");

        // Logovanje za proveru vrednosti
        Console.WriteLine($"SecretKey in UserService constructor: {_jwtSettings.SecretKey}");
    }

    private string GetIpAddress()
    {
        var ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        Console.WriteLine($"IP Address: {ipAddress}"); // Logovanje IP adrese
        return ipAddress;
    }


    public async Task<string> Authenticate(string username, string password)
    {
        var user = await _context.Users
            .Include(u => u.UserProfile)
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.UserProfile.Username == username && u.UserProfile.PasswordHash == password);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return null;
        }

        // Logovanje korisničkih podataka
        Console.WriteLine($"Authenticated User: {user.UserProfile.Username}");
        Console.WriteLine($"RoleName: {user.Roles?.RoleName}");

        // Provera vrednosti pre generisanja tokena
        Console.WriteLine($"SecretKey before calling GenerateJwtToken: {_jwtSettings.SecretKey}");

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        if (user == null || user.UserProfile == null)
        {
            throw new ArgumentNullException(nameof(user), "User or UserProfile cannot be null");
        }

        var secretKey = _jwtSettings.SecretKey ?? throw new ArgumentNullException(nameof(_jwtSettings.SecretKey), "SecretKey cannot be null");

        // Logovanje vrednosti pre enkodiranja
        Console.WriteLine($"SecretKey before encoding: {secretKey}");

        var key = Encoding.ASCII.GetBytes(secretKey);

        // Logovanje vrednosti nakon enkodiranja
        Console.WriteLine($"Encoded SecretKey length: {key.Length}");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserProfile.Username ?? throw new ArgumentNullException(nameof(user.UserProfile.Username))),
                new Claim(ClaimTypes.Role, user.Roles?.RoleName ?? throw new ArgumentNullException(nameof(user.Roles.RoleName)))
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenValidityInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string> GenerateRefreshToken(string username)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.UserProfile.Username == username);

        if (user == null)
            return null;

        // Generate new refresh token
        var refreshToken = new MyAuthenticationToken
        {
            Value = MyTokenGenerator.Generate(32),
            UserId = user.UserId,
            RecordedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenValidityInDays),
            IpAddress = GetIpAddress() // Korišćenje prave IP adrese
        };

        _context.MyAuthenticationTokens.Add(refreshToken);
        await _context.SaveChangesAsync();

        return refreshToken.Value;
    }


    public async Task<string> RefreshToken(string token)
    {
        var authToken = await _context.MyAuthenticationTokens.Include(t => t.User)
            .SingleOrDefaultAsync(t => t.Value == token && t.ExpiresAt > DateTime.UtcNow);

        if (authToken == null)
            return null;

        // Generate new JWT token
        var newJwtToken = GenerateJwtToken(authToken.User);

        // Optionally, generate new refresh token
        var newRefreshToken = await GenerateRefreshToken(authToken.User.UserProfile.Username);

        return newJwtToken; // Return both tokens if needed
    }
}
