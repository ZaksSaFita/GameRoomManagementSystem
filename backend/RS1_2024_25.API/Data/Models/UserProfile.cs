using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }



        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? ProfilePicture { get; set; }

    }




}
