using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;


[Route("user")]
[ApiController]
public class GetUserById :
    MyEndpointBaseAsync.WithRequest<GetUserByIdRequest>.WithActionResult<GetUserByIdResponse>
{
    private readonly ApplicationDbContext _context;

    public GetUserById(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("byId")]
    public override async Task<ActionResult<GetUserByIdResponse>> HandleAsync(
        [FromQuery] GetUserByIdRequest request,
        CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(u => u.UserProfile)
            .Include(u => u.City)
            .Include(u => u.Country)
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        if (user == null)
        {
            return NotFound();
        }

        var response = new GetUserByIdResponse
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.UserProfile.Username,
            Email = user.UserProfile.Email,
            PhoneNumber = user.PhoneNumber,
            CityName = user.City.CityName,
            CountryName = user.Country.CountryName,
            RoleName = user.Roles.RoleName
        };

        return Ok(response);
    }
}

public class GetUserByIdRequest
{
    public int UserId { get; set; }
}
public class GetUserByIdResponse
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CityName { get; set; }
    public string CountryName { get; set; }
    public string RoleName { get; set; }
}
