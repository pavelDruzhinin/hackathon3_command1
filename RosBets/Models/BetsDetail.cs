using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class BetsDetail
    {
        
        public int BetsId { get; set; }
        public Bet Bets { get; set; }
        [MaxLength(448)]
        public string Event { get; set; }

        public float Cef { get; set; }

        public bool? Success { get; set; }

        public bool P1 { get; set; }

        public bool X { get; set; }

        public bool P2 { get; set; }

        
    }
}