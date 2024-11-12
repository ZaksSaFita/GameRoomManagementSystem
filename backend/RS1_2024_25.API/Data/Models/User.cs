using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    public UserProfile? UserProfile { get; set; }
    public ICollection<UserAchievement>? UserAchievements { get; set; }
    public ICollection<UserLevel>? Levels { get; set; }
    public ICollection<UserTeam>? Teams { get; set; }
    public ICollection<UserTournament>? Tournaments { get; set; }
    public ICollection<UserCoin>? UserCoins { get; set; }



    //Attributes
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }

    //Foreign key
    [ForeignKey(nameof(City))]
    public int CityId { get; set; }
    public City? City { get; set; }

    //Foreign key
    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    //Foreign key
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public Role? Roles { get; set; }

}
