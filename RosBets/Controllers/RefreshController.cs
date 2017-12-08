using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;

namespace RosBets.Controllers
{
    
    public class RefreshController : Controller
    {
        RosBetsContext db = new RosBetsContext();

        [HttpPost]
        public JsonResult GetCoefficients(int champId)
        {
            var matchEvents = db.MatchEvents
                .Where(x => x.Match.ChampionshipId == champId)
                .Select(s => new
                {
                    s.MatchId,
                    s.EventId,
                    s.EventValue
                });
            return Json(matchEvents);
        }
    }
}