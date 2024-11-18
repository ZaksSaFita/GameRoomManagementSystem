using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.GameSessionEndpoints
{
    [Route("gamesession")]
    [ApiController]
    public class StartSessionEndpoint : MyEndpointBaseAsync.WithRequest<StartSessionRequest>.WithActionResult<GameSession>
    {
        private readonly ApplicationDbContext _context;
        public StartSessionEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("start")]
        public override async Task<ActionResult<GameSession>> HandleAsync(StartSessionRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(u => u.UserCoins).FirstOrDefaultAsync(u => u.UserId == request.UserId);
            var device = await _context.Devices.FindAsync(request.DeviceId);

            if (user == null || device == null || !device.IsAvailable)
            {
                return BadRequest();
            }

            //for now 1 coin = 10 minute playtime
            var maxPlaytime = user.UserCoins.Sum(uc => uc.Amount) * 10;

            var gameSession = new GameSession
            {
                UserId = request.UserId,
                DeviceId = request.DeviceId,
                StartTime = DateTime.Now,
                Duration = maxPlaytime
            };

            _context.GameSessions.Add(gameSession);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(gameSession);
        }
    }



    public class StartSessionRequest
    {
        public int UserId { get; set; }
        public int DeviceId { get; set; }
    }
}
