using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;

namespace RosBets.Controllers
{
    public class LineController : Controller
    {
        // GET: Line
        RosBetsContext db = new RosBetsContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Football()
        {
            var line = db.Matches.Include(x => x.MatchEvents).ToList();
            return View(line);
        }
    }
}