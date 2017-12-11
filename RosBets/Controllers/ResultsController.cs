using RosBets.Context;
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
        public ActionResult ShowResults()
        {
            //var results = (from u in db.Matches
            //               where u.Finished == true
            //               select u).ToList();


            var results = db.Matches.Include(x => x.Championship).Where(c => c.Finished == true).OrderBy(x => x.Championship.Name).ToList();
            
            return View(results);
        }
    }
}