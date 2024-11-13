using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services.User;

namespace RS1_2024_25.API.Endpoints.AuthEndpoints
{
    [Route("auth")]
    [ApiController]
    public class AuthLoginEndpoint(IUserService userService) : MyEndpointBaseAsync
        .WithRequest<AuthLoginEndpoint.LoginRequest>
        .WithActionResult<AuthLoginEndpoint.AuthResponse>
    {
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public override async Task<ActionResult<AuthResponse>> HandleAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var token = await _userService.Authenticate(request.Username, request.Password);

            if (token == null)
                return Unauthorized("Invalid username or password");

            var refreshToken = await _userService.GenerateRefreshToken(request.Username);
            /* var role = await _userService.GetUserRole(request.Username); */// Assuming GetUserRole method exists

            return Ok(new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
            });
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class AuthResponse
        {
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }


        [HttpPost("refresh")]
        public async Task<ActionResult<AuthResponse>> RefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            var newToken = await _userService.RefreshToken(request.RefreshToken);

            if (newToken == null)
                return Unauthorized("Invalid refresh token");

            var newRefreshToken = await _userService.GenerateRefreshToken(request.Username);
            /* var role = await _userService.GetUserRole(request.Username);*/ // Assuming GetUserRole method exists

            return Ok(new AuthResponse
            {
                Token = newToken,
                RefreshToken = newRefreshToken,
            });
        }
    }

    public class RefreshTokenRequest
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
    }


}
