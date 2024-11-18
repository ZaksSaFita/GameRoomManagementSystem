using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.UserEndpoint
{
    [Route("gamesession")]
    [ApiController]
    public class GetUserPlaytimeEndpoint : MyEndpointBaseAsync.WithRequest<GetUserPlaytimeRequest>.WithActionResult<UserPlaytimeResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetUserPlaytimeEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("user-playtime/{userId}")]
        public override async Task<ActionResult<UserPlaytimeResponse>> HandleAsync(GetUserPlaytimeRequest request, CancellationToken cancellationToken = default)
        {
            var totalPlaytime = await _context.GameSessions
                .Where(gs => gs.UserId == request.UserId)
                .SumAsync(gs => gs.ActualPlayTime, cancellationToken);

            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var response = new UserPlaytimeResponse
            {
                UserId = user.UserId,
                UserName = user.UserProfile.Username,
                TotalPlaytime = totalPlaytime
            };

            return Ok(response);
        }
    }

    public class GetUserPlaytimeRequest
    {
        public int UserId { get; set; }
    }

    public class UserPlaytimeResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TotalPlaytime { get; set; } // u minutama
    }
}
