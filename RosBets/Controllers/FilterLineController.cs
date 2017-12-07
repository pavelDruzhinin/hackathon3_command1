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
                    matches = db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => x.Date == DateTime.Now)
                        .ToList();
                    break;
                case 3:
                    DateTime currentTime = DateTime.Now.AddHours(1);
                    matches=db.Matches
                        .Include(x => x.MatchEvents)
                        .Where(x => x.Date >= currentTime && x.Date==DateTime.Today)
                        .ToList();
                    break;
            }
            var sports = db.Sports
                .Include(x => x.Championships)
                .ToList();
            var view = new FilterLineViewModel()
            {
                Sports = sports,
                Matches = matches
            };
            return View(view);
        }
    }
}