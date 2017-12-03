using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class CouponEvent
    {
        public int Id { get; set; }

        public string Coupon { get; set; }
        
        [ForeignKey("MatchEvent"), Column(Order = 0)]
        public int? MatchId { get; set; }
        public Match Match { get; set; }

        [ForeignKey("MatchEvent"), Column(Order = 1)]
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public MatchEvent MatchEvent { get; set; }

        public float Coefficient { get; set; }
        public float? Total { get; set; }

    }
}