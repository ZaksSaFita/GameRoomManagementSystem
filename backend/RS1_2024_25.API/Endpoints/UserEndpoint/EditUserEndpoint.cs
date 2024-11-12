using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.UserEndpoint
{
    [Route("user")]
    [ApiController]
    public class EditUserEndpoint : MyEndpointBaseAsync
        .WithRequest<EditUserRequest>
        .WithActionResult<EditUserResponse>
    {
        private readonly ApplicationDbContext _context;

        public EditUserEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("edit")]
        public override async Task<ActionResult<EditUserResponse>> HandleAsync([FromBody] EditUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(u => u.UserProfile)
                .SingleOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return NotFound(new EditUserResponse { Message = "User not found" });
            }

            // Ažuriranje korisničkih podataka
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.CityId = request.CityId;
            user.CountryId = request.CountryId;
            user.RoleId = request.RoleId;
            user.UserProfile.Username = request.Username;
            user.UserProfile.Email = request.Email;
            user.UserProfile.PasswordHash = request.Password; // U stvarnoj aplikaciji, koristite hashiranje

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new EditUserResponse { UserId = user.UserId, Message = "User updated successfully" });
        }
    }
}
public class EditUserRequest
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public int RoleId { get; set; }
}

public class EditUserResponse
{
    public int UserId { get; set; }
    public string Message { get; set; }
}
