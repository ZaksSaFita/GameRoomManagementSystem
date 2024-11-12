using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Prize { get; set; }

        // Foreign key
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        public ICollection<UserTournament>? Participants { get; set; }
    }

}
