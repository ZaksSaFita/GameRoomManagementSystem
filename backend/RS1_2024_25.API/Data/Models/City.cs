using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string? CityName { get; set; }

        // Foreign key
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
