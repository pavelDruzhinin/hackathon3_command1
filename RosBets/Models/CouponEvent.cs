using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class CouponEvent : EntityBase
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Coupon { get; set; }

        [DataMember]
        [ForeignKey("MatchEvent"), Column(Order = 0)]
        public int? MatchId { get; set; }
        public Match Match { get; set; }

        [DataMember]
        [ForeignKey("MatchEvent"), Column(Order = 1)]
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public MatchEvent MatchEvent { get; set; }

        [DataMember]
        public float Coefficient { get; set; }

        [DataMember]
        public float? Total { get; set; }

    }
}