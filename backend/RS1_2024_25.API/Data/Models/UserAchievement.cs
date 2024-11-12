using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserAchievement
    {
        [Key]
        public int UserAchievementId { get; set; }

        [ForeignKey(nameof(Achievement))]
        public int AchievementId { get; set; }
        public Achievement? Achievement { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }


        public DateTime DateEarned { get; set; }

    }
}
