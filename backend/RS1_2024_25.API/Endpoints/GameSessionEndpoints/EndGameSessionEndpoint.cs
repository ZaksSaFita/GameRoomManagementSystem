using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.GameSessionEndpoints
{
    [Route("gamesession")]
    [ApiController]
    public class EndGameSessionEndpoint : MyEndpointBaseAsync.WithRequest<EndGameSessionRequest>.WithActionResult<GameSession>
    {
        private readonly ApplicationDbContext _context;
        public EndGameSessionEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("end")]
        public override async Task<ActionResult<GameSession>> HandleAsync(EndGameSessionRequest request, CancellationToken cancellationToken)
        {
            var gameSession = await _context.GameSessions.FindAsync(request.GameSessionId);
            if (gameSession == null)
            {
                return NotFound();
            }

            var endTime = DateTime.Now;
            var actualPlayTime = (int)(endTime - gameSession.StartTime).TotalMinutes;

            gameSession.ActualPlayTime = actualPlayTime;

            var device = await _context.Devices.FindAsync(gameSession.DeviceId);
            if (device != null)
            {
                device.IsAvailable = true;
                device.CurrentUser = null;
                device.StartTime = null;
                device.MaxPlayTime = 0;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Ok(gameSession);
        }
    }
}
public class EndGameSessionRequest
{
    public int GameSessionId
    {
        get; set;
    }
}

