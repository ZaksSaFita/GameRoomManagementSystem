using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserTournament
    {
        [Key]
        public int UserTournamentId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }
        public Tournament? Tournament { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }

}
