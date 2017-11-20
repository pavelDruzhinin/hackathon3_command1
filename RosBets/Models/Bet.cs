using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public bool? Success { get; set; }
        public List<BetsDetail> BetsDetails { get; set; }
    }
}