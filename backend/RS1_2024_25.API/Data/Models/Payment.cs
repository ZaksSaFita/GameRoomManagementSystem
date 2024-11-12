using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        //Foreign keys
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        //Foreign keys
        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }


        //Attributes
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CoinAmount { get; set; } //User coins after payment
        public int ExpGained { get; set; } //Experience points gained after payment
    }
}
