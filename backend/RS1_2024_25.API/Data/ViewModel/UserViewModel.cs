using RS1_2024_25.API.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.ViewModel
{
    public class UserViewModel

    {
        public int Id { get; set; }
        public string Username { get; set; }

        // Additional properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? ImageUrl { get; set; }

        // Extras
        public int RatingPoints { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int Credits { get; set; }

        //Roles
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool isUser { get; set; }


        // foreign key
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
        public string? Country => City?.Country?.CountryName;

    }
}

