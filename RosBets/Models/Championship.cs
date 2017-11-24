using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public List<Match>  Matches { get; set; }
       

    }
}