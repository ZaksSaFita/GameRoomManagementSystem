using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserLevel
    {
        [Key]
        public int UserLevelId { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExperienceRequired { get; set; }

        //Foreign key
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }
    }

}
