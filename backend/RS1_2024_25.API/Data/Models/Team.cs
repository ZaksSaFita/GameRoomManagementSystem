using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? Name { get; set; }

        [ForeignKey(nameof(Captain))]
        public int CaptainId { get; set; }
        public User? Captain { get; set; }

        public ICollection<UserTeam>? Members { get; set; }


    }
}
