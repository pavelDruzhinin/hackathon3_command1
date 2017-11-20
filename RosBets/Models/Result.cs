using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Result
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Event { get; set; }

        public int FirstResult { get; set; }

        public int SecondResult { get; set; }

        public bool Calculated { get; set; }
    }
}