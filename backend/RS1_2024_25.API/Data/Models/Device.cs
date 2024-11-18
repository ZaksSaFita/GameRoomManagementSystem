using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string? DeviceType { get; set; } //PC, Xbox, PlayStation...
        public bool IsAvailable { get; set; } = true;
        public int? CurrentUserId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? MaxPlayTime { get; set; }   //in minutes

        [ForeignKey(nameof(CurrentUserId))]
        public User CurrentUser { get; set; }
    }
}
