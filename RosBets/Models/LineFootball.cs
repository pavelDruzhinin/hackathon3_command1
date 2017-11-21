using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class LineFootball
    {
        public int Id { get; set; }

        public string IdGames { get; set; }

        public DateTime? Date { get; set; }
        public string Championat { get; set; }

        public string Event { get; set; }

        public float? P1 { get; set; }

        public float? X { get; set; }

        public float? P2 { get; set; }
    }
}