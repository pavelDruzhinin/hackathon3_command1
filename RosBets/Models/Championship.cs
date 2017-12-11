using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RosBets.Models
{
    public class Championship : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public List<Match>  Matches { get; set; }
       

    }
}