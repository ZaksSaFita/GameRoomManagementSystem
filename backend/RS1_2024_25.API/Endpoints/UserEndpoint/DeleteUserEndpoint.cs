using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;

namespace RS1_2024_25.API.Endpoints.UserEndpoint
{
    [Route("user")]
    [ApiController]
    public class DeleteUserEndpoint : MyEndpointBaseAsync
        .WithRequest<DeleteUserRequest>
        .WithActionResult<DeleteUserResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("delete")]
        public override async Task<ActionResult<DeleteUserResponse>> HandleAsync([FromQuery] DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(u => u.UserProfile)
                .SingleOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return NotFound(new DeleteUserResponse { Message = "User not found" });
            }

            _context.UserProfiles.Remove(user.UserProfile);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new DeleteUserResponse { Message = "User deleted successfully" });
        }
    }
}
public class DeleteUserRequest
{
    public int UserId { get; set; }
}

public class DeleteUserResponse
{
    public string Message { get; set; }
}
