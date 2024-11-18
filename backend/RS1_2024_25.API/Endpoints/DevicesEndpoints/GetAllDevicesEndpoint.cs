using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.DevicesEndpoints
{
    [Route("devices")]
    [ApiController]
    public class GetAllDevicesEndpoint : MyEndpointBaseAsync.WithoutRequest.WithActionResult<GetAllDevicesResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllDevicesEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public override async Task<ActionResult<GetAllDevicesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var devices = await _context.Devices
                .Select(x => new GetAllDevicesResponse
                {
                    DeviceId = x.DeviceId,
                    DeviceType = x.DeviceType,
                    IsAvailable = x.IsAvailable,
                    CurrentUserId = x.CurrentUserId,
                    StartTime = x.StartTime,
                    MaxPlayTime = x.MaxPlayTime
                })
                .ToListAsync(cancellationToken);

            return Ok(devices);
        }
    }

    public class GetAllDevicesResponse
    {
        public int DeviceId { get; set; }
        public string DeviceType { get; set; }
        public bool IsAvailable { get; set; }
        public int? CurrentUserId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? MaxPlayTime { get; set; }
    }
}
