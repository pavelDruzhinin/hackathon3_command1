using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RosBets.Models;

namespace RosBets.ViewModels
{
    public class CouponViewModel
    {
        public List<CouponEvent> CouponEvents { get; set; }
        public float? TotalCoefficient { get; set; }
    }
}