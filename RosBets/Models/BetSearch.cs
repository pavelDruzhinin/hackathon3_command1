using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class BetSearch
    {
        public string MatchName { get; set; }

        public DateTime? Date { get; set; }

        public bool? Success { get; set; }

        public int Id { get; set; }

        public float TotalCoefficient { get; set; }

        public string Shortname { get; set; }

        public List<BetEvent> BetEvents { get; set; }
    }



}