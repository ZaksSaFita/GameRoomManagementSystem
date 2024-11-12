using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Data.Models
{
    public class Coin
    {
        [Key]
        public int CoinId { get; set; }
        public string? Name { get; set; }

        public int Value { get; set; }

        public ICollection<UserCoin>? UserCoins { get; set; }
    }

}
