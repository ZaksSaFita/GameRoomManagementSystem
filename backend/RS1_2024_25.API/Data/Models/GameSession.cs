using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class GameSession
    {
        public int GameSessionId { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }   //in minutes
        public int ActualPlayTime { get; set; } //in minutes

        //Foreign key
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        //Foreign key
        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }
        public Device? Device { get; set; }
    }
}
