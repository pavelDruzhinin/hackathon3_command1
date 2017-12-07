using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Event:EntityBase
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Shortname { get; set; }

        [DataMember]
        public string FullName { get; set; }

        public List<BetEvent> BetEvents { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
    }
}