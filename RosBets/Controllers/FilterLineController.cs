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
    public class FilterLineController : Controller
    {
        // GET: FilterLine

        RosBetsContext db = new RosBetsContext();

        public ActionResult Index(int? id)
        {
            var matches = new List<Match>();

            var serverTime = DateTime.Now;
            var localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Russian Standard Time");

            switch (id)
            {
                case 1:
                    matches = db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x=>x.Date>localTime)
                        .ToList();
                    ViewBag.Title = "Ставки не важно на какой день";
                    break;
                case 2:
                    var Date = DateTime.Now;
                    Date = Date.Date;
                    matches = db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => x.Date.Value.Day == localTime.Day && x.Date>localTime)
                        .ToList();
                    ViewBag.Title = "Ставки на сегодня";
                    break;
                case 3: //ближайший час
                    var NextHour = localTime.AddHours(1);
                    matches=db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => (x.Date >= localTime && x.Date<=NextHour) && x.Date>localTime)
                        .ToList();
                    ViewBag.Title = "Ставки на ближайший час";
                    break;
                default:
                    return RedirectToAction("Index", "Home");
            }
            var champ = db.Championships
                .ToList();
            var view = new FilterLineViewModel()
            {
                Championships = champ,
                Matches = matches
            };
            if (matches.Count != 0)
            {
                return View(view);
            }
            else { ModelState.AddModelError("","На данный момент нет матчей"); return View(); }
        }
    }
}