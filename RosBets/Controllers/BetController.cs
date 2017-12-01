using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;
using RosBets.ViewModels;

namespace RosBets.Controllers
{
    public class BetController : Controller
    {
        RosBetsContext db = new RosBetsContext();

        [ChildActionOnly]
        public ActionResult RenderCoupon()
        {
            var coupon = Coupon.GetCoupon(HttpContext);
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
        }

        [HttpPost]
        public ActionResult AddToCoupon(string id)
        {
            var ids = id.Split('_');
            var eventId = int.Parse(ids[0]);
            var matchId = int.Parse(ids[1]);
            var matchEvent = db.MatchEvents.SingleOrDefault(m => m.EventId == eventId && m.MatchId == matchId);
            var coupon = Coupon.GetCoupon(HttpContext);
            if (matchEvent != null)
            {
                coupon.AddToCoupon(matchEvent);
            }
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
        }

        [HttpPost]
        [ChildActionOnly]
        public ActionResult RemoveFromCoupon(string id)
        {
            var couponEventId = int.Parse(id);
            var coupon = Coupon.GetCoupon(HttpContext);
            coupon.RemoveFromCoupon(couponEventId);
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
        }
    }
}