using RosBets.Context;
using RosBets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosBets.Controllers
{
    public class ResultsController : Controller
    {
        RosBetsContext db = new RosBetsContext();

        //// GET: Results
        public ActionResult ShowResults()
        {

            List<Sport> sports = db.Sports.
                Where(x => x.Name != null)
                .ToList();

            return View(sports);
        }


        public ActionResult MyShowResults()
        {
            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);

            List<Match> results = db.Matches
                .Where(x => x.Finished == true)
                .Include(x => x.Championship)
                .Include(z => z.Championship.Sport)
                .OrderBy(x => x.Date)
                .ToList();

            return PartialView("_ShowResults", results);
        }


        [HttpPost]
        public ActionResult MyShowResults(string date, string sport)
        {
            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);

            DateTime myDate = DateTime.Parse(date);

            List<Match> results = db.Matches
                .Where(x => x.Finished == true)
                .Include(x => x.Championship)
                .Include(z => z.Championship.Sport)
                .Include(y => y.Championship.Sport.Name)
                .OrderBy(x => x.Date)
                .ToList();

            switch (sport)
            {
                case "Все":
                    results = results
                   .Where(y => y.Date == myDate)
                   .ToList();
                    break;

                case "Футбол":
                    results = results
                   .Where(x => x.Championship.Sport.Name == "Футбол")
                   .Where(y => y.Date == myDate)
                   .ToList();
                    break;
                case "Хоккей":
                    results = results
                   .Where(x => x.Championship.Sport.Name == "Футбол")
                   .Where(y => y.Date == myDate)
                   .ToList();
                    break;
            }

            return PartialView("_ShowResults", results);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}