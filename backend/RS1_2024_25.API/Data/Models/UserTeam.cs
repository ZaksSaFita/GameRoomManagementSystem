using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserTeam
    {
        [Key] public int UserTeamId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [ForeignKey(nameof(TeamRole))]
        public int TeamRoleId { get; set; }
        public TeamRole? Role { get; set; }

        public DateTime JoinDate { get; set; }



    }
}