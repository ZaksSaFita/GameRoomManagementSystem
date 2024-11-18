using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.DeviceEndpoint
{
    [Route("gamesession")]
    [ApiController]
    public class GetDevicePlaytimeEndpoint : MyEndpointBaseAsync.WithRequest<GetDevicePlaytimeRequest>.WithActionResult<DevicePlaytimeResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetDevicePlaytimeEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("device-playtime/{deviceId}")]
        public override async Task<ActionResult<DevicePlaytimeResponse>> HandleAsync(GetDevicePlaytimeRequest request, CancellationToken cancellationToken = default)
        {
            var totalPlaytime = await _context.GameSessions
                .Where(gs => gs.DeviceId == request.DeviceId)
                .SumAsync(gs => gs.ActualPlayTime, cancellationToken);

            var device = await _context.Devices.FindAsync(request.DeviceId);
            if (device == null)
            {
                return NotFound();
            }

            var response = new DevicePlaytimeResponse
            {
                DeviceId = device.DeviceId,
                DeviceType = device.DeviceType,
                TotalPlaytime = totalPlaytime
            };

            return Ok(response);
        }
    }

    public class GetDevicePlaytimeRequest
    {
        public int DeviceId { get; set; }
    }

    public class DevicePlaytimeResponse
    {
        public int DeviceId { get; set; }
        public string DeviceType { get; set; }
        public int TotalPlaytime { get; set; } // u minutama
    }
}
