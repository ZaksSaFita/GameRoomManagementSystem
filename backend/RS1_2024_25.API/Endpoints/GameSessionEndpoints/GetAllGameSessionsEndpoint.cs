using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.GameSessionEndpoint
{
    [Route("gamesession")]
    [ApiController]
    public class GetAllGameSessionsEndpoint : MyEndpointBaseAsync.WithoutRequest.WithActionResult<List<GameSessionResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllGameSessionsEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public override async Task<ActionResult<List<GameSessionResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var gameSessions = await _context.GameSessions
                .Include(gs => gs.User)
                .Include(gs => gs.Device)
                .Select(gs => new GameSessionResponse
                {
                    GameSessionId = gs.GameSessionId,
                    UserId = gs.UserId,
                    UserName = gs.User.UserProfile.Username,
                    DeviceId = gs.DeviceId,
                    DeviceType = gs.Device.DeviceType,
                    StartTime = gs.StartTime,
                    Duration = gs.Duration,
                    ActualPlayTime = gs.ActualPlayTime
                })
                .ToListAsync(cancellationToken);

            return Ok(gameSessions);
        }
    }

    public class GameSessionResponse
    {
        public int GameSessionId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int ActualPlayTime { get; set; }
    }
}
