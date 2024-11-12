using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Services.SeedData;

namespace RS1_2024_25.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly SeedDataService _seedDataService;

        public SeedDataController(SeedDataService seedDataService)
        {
            _seedDataService = seedDataService;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabase()
        {
            await _seedDataService.SeedAsync();
            return Ok("Database has been seeded successfully!");
        }
    }
}
