using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.UserEndpoint
{
    [Route("user")]
    [ApiController]
    public class AddUserEndpoint : MyEndpointBaseAsync
        .WithRequest<AddUserRequest>
        .WithActionResult<AddUserResponse>
    {
        private readonly ApplicationDbContext _context;

        public AddUserEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public override async Task<ActionResult<AddUserResponse>> HandleAsync([FromBody] AddUserRequest request, CancellationToken cancellationToken = default)
        {
            // Proverite da li korisnik sa istim korisničkim imenom već postoji
            if (await _context.UserProfiles.AnyAsync(up => up.Username == request.Username, cancellationToken))
            {
                return BadRequest(new AddUserResponse { Message = "Username already exists" });
            }

            // Kreiranje novog korisnika
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                CityId = request.CityId,
                CountryId = request.CountryId,
                RoleId = request.RoleId,
                UserProfile = new UserProfile
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = request.Password // U stvarnoj aplikaciji, koristite hashiranje
                }
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new AddUserResponse { UserId = newUser.UserId, Message = "User created successfully" });
        }
    }

    public class AddUserRequest
    {
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

    public class AddUserResponse
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }

}
