using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Data.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BadgeImage { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Points { get; set; }

        public ICollection<UserAchievement>? UserAchievements { get; set; }

    }

}
