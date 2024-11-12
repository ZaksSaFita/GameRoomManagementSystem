using Bogus;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;

namespace RS1_2024_25.API.Services.SeedData
{
    public class SeedDataService
    {
        private readonly ApplicationDbContext _context;

        public SeedDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // generate countries
            var fakeCountry = new Faker<Country>()
                .RuleFor(c => c.CountryName, f => f.Address.Country());
            var countries = fakeCountry.Generate(10);
            _context.Countries.AddRange(countries);
            await _context.SaveChangesAsync();

            // generate cities
            var fakeCity = new Faker<City>()
                .RuleFor(c => c.CityName, f => f.Address.City())
                .RuleFor(c => c.CountryId, f => f.PickRandom(countries).CountryId);
            var cities = fakeCity.Generate(10);
            _context.Cities.AddRange(cities);
            await _context.SaveChangesAsync();

            // generate locations
            var fakeLocation = new Faker<Location>()
                .RuleFor(l => l.Name, f => f.Company.CompanyName())
                .RuleFor(l => l.Address, f => f.Address.FullAddress())
                .RuleFor(l => l.CityId, f => f.PickRandom(cities).CityId)
                .RuleFor(l => l.CountryId, f => f.PickRandom(countries).CountryId);
            var locations = fakeLocation.Generate(10);
            _context.Locations.AddRange(locations);
            await _context.SaveChangesAsync();

            // generate roles
            var roles = new List<Role>
            {
                   new Role { RoleName = "Admin" },
                   new Role { RoleName = "Employee" },
                   new Role { RoleName = "User" },
            };
            _context.Roles.AddRange(roles);
            await _context.SaveChangesAsync();

            // generate team roles
            var teamRoles = new List<TeamRole>
            {
                new TeamRole { TeamRoleName = "Captain" },
                new TeamRole { TeamRoleName = "Player" }
            };

            // generate payment methods
            var paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod { MethodName="Cash"},
                new PaymentMethod { MethodName="Card"},
                new PaymentMethod { MethodName="Coupone"}
            };
            _context.PaymentMethods.AddRange(paymentMethods);
            await _context.SaveChangesAsync();

            // generate coins
            var coins = new List<Coin>
           {
               new Coin { Name = "GC1", Value=100 },
               new Coin { Name = "GC2", Value=200 },
               new Coin { Name = "GC3", Value=300 },
               new Coin { Name = "GC4", Value=400 },
               new Coin { Name = "GC5", Value=500 },


           };
            _context.Coins.AddRange(coins);
            await _context.SaveChangesAsync();


            //generate zahir
            var adminRole = roles.FirstOrDefault(r => r.RoleName == "Admin");
            var adminUser = new RS1_2024_25.API.Data.Models.User
            {
                FirstName = "Admin",
                LastName = "User",
                DateOfBirth = DateTime.Now.AddYears(-30),
                PhoneNumber = "1234567890",
                CityId = cities.First().CityId,
                CountryId = countries.First().CountryId,
                RoleId = adminRole.RoleId,
                UserProfile = new UserProfile
                {
                    Username = "zahir",
                    PasswordHash = "1",
                    Email = "zahir@example.com",
                    ProfilePicture = null
                }
            };
            _context.Users.AddRange(adminUser);
            await _context.SaveChangesAsync();


            // generate users
            var fakeUser = new Faker<RS1_2024_25.API.Data.Models.User>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.CityId, f => f.PickRandom(cities).CityId)
                .RuleFor(u => u.CountryId, f => f.PickRandom(countries).CountryId)
                .RuleFor(u => u.RoleId, f => f.PickRandom(roles).RoleId)
                .RuleFor(u => u.UserProfile, f => new UserProfile
                {
                    Username = f.Internet.UserName(),
                    PasswordHash = f.Internet.Password(),
                    Email = f.Internet.Email(),
                    ProfilePicture = f.Image.PicsumUrl(),
                });
            var users = fakeUser.Generate(10);
            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();




        }
    }
}
