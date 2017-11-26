using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        public bool? Success { get; set; }

        public decimal BetAmount { get; set; }//Сумма ставки
        public float TotalCoefficient { get; set; }
        public decimal? Payout { get; set; }//к ваплате
        
        public List<BetEvent> BetEvents { get; set; }
    }
}