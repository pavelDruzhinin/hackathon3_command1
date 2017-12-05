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
        public ActionResult RemoveFromCoupon(int id)
        {
            var coupon = Coupon.GetCoupon(HttpContext);
            coupon.RemoveFromCoupon(id);
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
        }

        [HttpPost]
        public ActionResult CreateBet(decimal amount, int? couponEventId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var coupon = Coupon.GetCoupon(HttpContext);
            var user = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
            var bet = new Bet
            {
                UserId = user.Id,
                BetAmount = amount,
                Date = DateTime.Now
            };
            db.Bets.Add(bet);
            db.SaveChanges();
            coupon.CreateBet(bet, couponEventId);
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
        }
    }
}