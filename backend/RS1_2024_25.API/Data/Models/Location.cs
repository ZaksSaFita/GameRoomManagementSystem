using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models;

public class Location
{
    [Key]
    public int LocationId { get; set; }

    // Attributes
    public string? Name { get; set; }
    public string? Address { get; set; }

    // Foreign key
    [ForeignKey(nameof(City))]
    public int CityId { get; set; }
    public City? City { get; set; }

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    // Relationships
    public ICollection<Tournament>? Tournaments { get; set; }
}
