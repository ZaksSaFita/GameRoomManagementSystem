using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Data.Models;

public class Country
{
    [Key]
    public int CountryId { get; set; }

    // Attributes
    public string? CountryName { get; set; }

    // Relationships
    public ICollection<City>? Cities { get; set; }
    public ICollection<User>? Users { get; set; }
}
