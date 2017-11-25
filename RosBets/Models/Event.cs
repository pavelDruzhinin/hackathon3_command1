using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Event
    {
        public int Id { get; set; }
   
        public string Shortname { get; set; }
        public string FullName { get; set; }

        public List<BetEvent> BetEvents { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
    }
}