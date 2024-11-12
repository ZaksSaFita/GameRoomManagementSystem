using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.UserEndpoint
{
    [Route("user")]
    [ApiController]
    public class GetAllUsersEndpoint : MyEndpointBaseAsync.WithoutRequest.WithActionResult<GetAllUsersResponse>
    {
        private readonly ApplicationDbContext _context;
        public GetAllUsersEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public override async Task<ActionResult<GetAllUsersResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var users = await _context.Users
                .Include(x => x.UserProfile)
                .Include(x => x.City)
                .Include(x => x.Country)
                .Include(x => x.Roles)
                .Select(x => new GetAllUsersResponse
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.UserProfile.Username,
                    Email = x.UserProfile.Email,
                    PhoneNumber = x.PhoneNumber,
                    CityName = x.City.CityName,
                    CountryName = x.Country.CountryName,
                    RoleName = x.Roles.RoleName
                })
                .ToListAsync(cancellationToken);

            return Ok(users);
        }
    }

    public class GetAllUsersResponse
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? RoleName { get; set; }
    }

}
