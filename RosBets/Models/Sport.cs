using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Championship> Championships { get; set; }
    }
}