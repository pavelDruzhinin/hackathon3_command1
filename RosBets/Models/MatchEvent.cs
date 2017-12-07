using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class MatchEvent : EntityBase
    {
        [DataMember]
        [Key, Column(Order = 0)]
        public int MatchId { get; set; }
        public Match Match { get; set; }

        [DataMember]
        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [DataMember]
        public float EventValue { get; set; }
    }
}