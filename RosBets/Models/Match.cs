using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Team1Name { get; set; }

        public string Team2Name { get; set; }

        public DateTime? Date { get; set; }

        public string Championship { get; set; }

        public bool Finished { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public List<Bet> Bets { get; set; }

    }
}