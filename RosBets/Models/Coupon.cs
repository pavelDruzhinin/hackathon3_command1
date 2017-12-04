using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using System.Security;

namespace RosBets.Models
{
    public class Coupon
    {
        RosBetsContext db = new RosBetsContext();

        string CouponId { get; set; }

        public const string SessionKey = "CouponId";

        public static Coupon GetCoupon(HttpContextBase context)
        {
            var coupon = new Coupon();
            coupon.CouponId = coupon.GetCouponId(context);
            return coupon;
        }
        
        public static Coupon GetCoupon(Controller controller)
        {
            return GetCoupon(controller.HttpContext);
        }

        public void AddToCoupon(MatchEvent matchEvent)
        {
            var couponEvent = db.CouponEvents.SingleOrDefault(c => c.Coupon == CouponId
                     && c.MatchId == matchEvent.MatchId
                     && c.EventId == matchEvent.EventId);

            if (couponEvent == null)
            {
                var sameMatchEvents = db.CouponEvents.Where(x => x.MatchId == matchEvent.MatchId);
                if (sameMatchEvents.Any())
                {
                    db.CouponEvents.RemoveRange(sameMatchEvents);
                }
                couponEvent = new CouponEvent
                {
                    EventId = matchEvent.EventId,
                    MatchId = matchEvent.MatchId,
                    Coefficient = matchEvent.EventValue,
                    Coupon = CouponId
                };
                db.CouponEvents.Add(couponEvent);
            }
            else
            {
                db.CouponEvents.Remove(couponEvent);
            }
            db.SaveChanges();
        }

        public void RemoveFromCoupon(int id)
        {
            var couponEvent = db.CouponEvents.Single(c => c.Coupon == CouponId && c.Id == id);

            if (couponEvent != null)
            {
                db.CouponEvents.Remove(couponEvent);
            }
            db.SaveChanges();
        }

        public void ClearCoupon()
        {
            var couponEvents = db.CouponEvents.Where(c => c.Coupon == CouponId);

            foreach (var couponEvent in couponEvents)
            {
                db.CouponEvents.Remove(couponEvent);
            }
            db.SaveChanges();
        }

        public List<CouponEvent> GetCouponEvents()
        {
            return db.CouponEvents
                .Where(c => c.Coupon == CouponId)
                .Include(c=>c.Match)
                .Include(c=>c.Event)
                .ToList();
        }
        
        public float? GetCoefficient()
        {
            var coefficients = db.CouponEvents
                .Where(c => c.Coupon == CouponId)
                .Select(c => c.Coefficient).ToArray();

            float? totalCoefficient = coefficients.Aggregate(1f, (a, b) => a * b);


            return totalCoefficient;

        }

        public int CreateBet(Bet bet)
        {
            var couponEvents = GetCouponEvents();
            float totalCoefficient = 1f;
            foreach (var couponEvent in couponEvents)
            {
                var betEvent = new BetEvent
                {
                    BetId = bet.Id,
                    EventId = (int)couponEvent.EventId,
                    MatchId = (int)couponEvent.MatchId,
                    Coefficient = couponEvent.Coefficient,
                    BetEventStatusId = 4
                };
                totalCoefficient *= couponEvent.Coefficient;

                db.BetEvents.Add(betEvent);
            }
            bet.TotalCoefficient = totalCoefficient;
            bet.Payout = bet.BetAmount * (decimal)totalCoefficient;
            db.SaveChanges();
            ClearCoupon();

            return bet.Id;
        }
        
        public string GetCouponId(HttpContextBase context)
        {
            if (context.Session[SessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[SessionKey] = context.User.Identity.Name;
                }
                else
                {
                    var couponId = Guid.NewGuid();
                    context.Session[SessionKey] = couponId.ToString();
                }
            }
            return context.Session[SessionKey].ToString();
        }
        
        public void AssignUsername(string userName)
        {
            var couponEvents = db.CouponEvents.Where(c => c.Coupon == CouponId);

            foreach (var couponEvent in couponEvents)
            {
                couponEvent.Coupon = userName;
            }
            db.SaveChanges();
        }
    }
}