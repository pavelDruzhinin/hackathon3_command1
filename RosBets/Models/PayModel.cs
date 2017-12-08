using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosBets.Models
{
    public class PayModel
    {
        public int PayId { get; set; }
        public decimal Sum { get; set; }
        public string Name { get; set; }
    }
}