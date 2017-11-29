using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class BetSearch
    {
        string date;

        public string MatchName { get; set; }

        public DateTime? Date { get; set; }

        public bool? Success { get; set; }

        public int Id { get; set; }

        public float TotalCoefficient { get; set; }

        public string Shortname { get; set; }

        public List<BetEvent> BetEvents { get; set; }

        public string MyDate
        {
            set { }

            get
            {
                date = Date.HasValue ? Date.Value.ToString("yyyy-MM-dd HH:mm:ss") : "<not available>";
                return date;
            }
        }
    }



}