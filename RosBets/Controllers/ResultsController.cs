using PagedList;
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
        // GET: Results

        

        public ActionResult ShowResults(int? page, DateTime? date1, DateTime? date2, string sport = "Все")
        {
            var serverDate = DateTime.Now;
            var localDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverDate, TimeZoneInfo.Local.Id, "Russian Standard Time");

            if (date1 == null)
            {
                date1 = default(DateTime);
            }

            if (date2 == null)
            {
                date2 = localDate;
            }

            ViewBag.date1 = date1;
            ViewBag.date2 = date2;
            ViewBag.sport = sport;

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            List<Match> results = db.Matches
                   .Where(x => x.Finished == true)
                   .Include(x => x.Championship)
                   .Include(z => z.Championship.Sport)
                   .OrderBy(y => y.Championship.Name)
                   .ThenBy(x => x.Date)
                   .ToList();

            if (sport == "Все")
            {
                results = results
                   .Where(y => y.Date.Value.Date >= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date1.Value.Date, TimeZoneInfo.Local.Id, "Russian Standard Time"))
                   .Where(y => y.Date.Value.Date <= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date2.Value.Date, TimeZoneInfo.Local.Id, "Russian Standard Time"))
                   .ToList();

                return View(results.ToPagedList(pageNumber, pageSize));

            }

            results = results
                   .Where(x => x.Championship.Sport.Name == sport)
                   .Where(y => y.Date.Value.Date >= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date1.Value.Date, TimeZoneInfo.Local.Id, "Russian Standard Time"))
                   .Where(y => y.Date.Value.Date <= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date2.Value.Date, TimeZoneInfo.Local.Id, "Russian Standard Time"))
                   .ToList();

            return View(results.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}