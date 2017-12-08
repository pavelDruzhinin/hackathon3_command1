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
            switch (id)
            {
                case 1:
                    matches = db.Matches
                        .Include(x => x.MatchEvents)
                        .ToList();
                    break;
                case 2:
                    var Date = DateTime.Now;
                    Date = Date.Date;
                    matches = db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => x.Date.Value.Day == DateTime.Now.Day)
                        .ToList();
                    break;
                case 3:
                    DateTime NextHour = DateTime.Now.AddHours(1);
                    matches=db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => x.Date >= DateTime.Now && x.Date<=NextHour)
                        .ToList();
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