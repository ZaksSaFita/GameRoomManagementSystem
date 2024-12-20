﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class UserCoin
    {
        [Key]
        public int UserCoinId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Coin))]
        public int CoinId { get; set; }
        public Coin? Coin { get; set; }

        public int Amount { get; set; }
    }

}
