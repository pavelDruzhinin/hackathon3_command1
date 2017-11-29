using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class BetEvent
    {
        [Key, Column(Order = 0)]
        public int BetId { get; set; }
        public Bet Bet { get; set; }

        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Key, Column(Order = 2)]
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public BetEventStatus BetEventStatus { get; set; }
        public int? BetEventStatusId { get; set; }

    }
}