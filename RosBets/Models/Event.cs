using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    [DataContract(IsReference = true)]
    public class Event:EntityBase
    {
        public int Id { get; set; }

        public string Shortname { get; set; }

        public string FullName { get; set; }

        public List<BetEvent> BetEvents { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
    }
}