using System;
using System.Collections.Generic;
using System.Data.Entity;
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
      //  RosBetsContext db = new RosBetsContext();

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
            using (var db = new RosBetsContext())
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
        public ActionResult ClearCoupon()
        {
            var coupon = Coupon.GetCoupon(HttpContext);
            coupon.ClearCoupon();
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
            using (var db = new RosBetsContext())
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Json(new {result = "NotLoggedIn"});
                }
                var coupon = Coupon.GetCoupon(HttpContext);
                var user = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
                if (user.Money < amount)
                {
                    return Json(new {result = "NoMoney"});
                }
                var bet = new Bet
                {
                    UserId = user.Id,
                    BetAmount = amount,
                    Date = DateTime.Now
                };
                db.Bets.Add(bet);
                user.Money -= amount;
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

        [HttpPost]
        public ActionResult AllOrdinary(params BetTO[] couponEvents)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { result = "NotLoggedIn" });
            }
            var user = new User();
            using (var db = new RosBetsContext())
            {
                user = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
            }
            var betAmount = couponEvents.Sum(x => x.Value);
            if (betAmount > user.Money)
            {
                return Json(new {result = "NoMoney"});
            }
            var coupon = Coupon.GetCoupon(HttpContext);
            foreach (var e in couponEvents)
            {
                var bet = new Bet
                {
                    UserId = user.Id,
                    BetAmount = e.Value,
                    Date = DateTime.Now
                };
                using (var db = new RosBetsContext())
                {
                    db.Bets.Add(bet);
                    user.Money -= e.Value;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    coupon.CreateBet(bet, e.EventId);
                }
            }
            var viewmodel = new CouponViewModel
            {
                CouponEvents = coupon.GetCouponEvents(),
                TotalCoefficient = coupon.GetCoefficient()
            };
            return PartialView("right_column", viewmodel);
            
        }
    }
}