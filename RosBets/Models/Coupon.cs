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
        //RosBetsContext db = new RosBetsContext();

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
            using (var db = new RosBetsContext())
            {
                var couponEvent = db.CouponEvents
                    .SingleOrDefault(c => c.Coupon == CouponId
                    && c.MatchId == matchEvent.MatchId 
                    && c.EventId == matchEvent.EventId);
                float? totalValue = null;
                switch (matchEvent.EventId)
                {
                    case 2:
                    case 3:
                        totalValue = db.MatchEvents
                            .SingleOrDefault(x => x.MatchId == matchEvent.MatchId && x.EventId == 1).EventValue;
                        break;
                    case 11:
                    case 12:
                        totalValue = db.MatchEvents
                            .SingleOrDefault(x => x.MatchId == matchEvent.MatchId && x.EventId == 10).EventValue;
                        break;
                    case 14:
                    case 15:
                        totalValue = db.MatchEvents
                            .SingleOrDefault(x => x.MatchId == matchEvent.MatchId && x.EventId == 13).EventValue;
                        break;
                }
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
                        Coupon = CouponId,
                        Total = totalValue
                    };

                    db.CouponEvents.Add(couponEvent);
                }
                else
                {
                    db.CouponEvents.Remove(couponEvent);
                }
                db.SaveChanges();
            }
        }

        public void RemoveFromCoupon(int id)
        {
            using (var db = new RosBetsContext())
            {
                var couponEvent = db.CouponEvents.Single(c => c.Coupon == CouponId && c.Id == id);

                if (couponEvent != null)
                {
                    db.CouponEvents.Remove(couponEvent);
                }
                db.SaveChanges();
            }
        }

        public void ClearCoupon()
        {
            using (var db = new RosBetsContext())
            {
                var couponEvents = db.CouponEvents.Where(c => c.Coupon == CouponId);

                foreach (var couponEvent in couponEvents)
                {
                    db.CouponEvents.Remove(couponEvent);
                }
                db.SaveChanges();
            }
        }

        public List<CouponEvent> GetCouponEvents()
        {
            using (var db = new RosBetsContext())
            {
                return db.CouponEvents
                    .Where(c => c.Coupon == CouponId)
                    .Include(c => c.Match)
                    .Include(c => c.Match.Championship)
                    .Include(c => c.Event)
                    .ToList();
            }
        }

        public float? GetCoefficient()
        {
            float? totalCoefficient;
            using (var db = new RosBetsContext())
            {
                var coefficients = db.CouponEvents
                    .Where(c => c.Coupon == CouponId)
                    .Select(c => c.Coefficient).ToArray();

                totalCoefficient = coefficients.Aggregate(1f, (a, b) => a * b);
            }
            return totalCoefficient;
        }


        public void CreateBet(Bet bet, int? couponEventId)
        {
            using (var db = new RosBetsContext())
            {
                float totalCoefficient = 1f;
                List<CouponEvent> couponEvents = new List<CouponEvent>();

                if (couponEventId != null)
                {
                    couponEvents.Add(db.CouponEvents.Where(x => x.Id == couponEventId).FirstOrDefault());
                }
                else
                {
                    couponEvents = GetCouponEvents();
                }

                foreach (var couponEvent in couponEvents)
                {
                    var betEvent = new BetEvent
                    {
                        BetId = bet.Id,
                        EventId = (int) couponEvent.EventId,
                        MatchId = (int) couponEvent.MatchId,
                        Coefficient = couponEvent.Coefficient,
                        BetEventStatusId = 4,
                        Total = couponEvent.Total
                    };
                    totalCoefficient *= couponEvent.Coefficient;

                    db.BetEvents.Add(betEvent);
                    if (!db.CouponEvents.Local.Contains(couponEvent))
                    {
                        db.CouponEvents.Attach(couponEvent);
                    }
                    db.CouponEvents.Remove(couponEvent);
                    db.SaveChanges();
                }
                bet.TotalCoefficient = totalCoefficient;
                bet.Payout = bet.BetAmount * (decimal) totalCoefficient;

                db.Entry(bet).State = EntityState.Modified;
                db.SaveChanges();
            }
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
            using (var db = new RosBetsContext())
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
}