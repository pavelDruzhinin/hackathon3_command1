﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;
using RosBets.SqlServerNotifier;

namespace RosBets.Controllers
{
    public class LineController : Controller
    {
        // GET: Line
        RosBetsContext db = new RosBetsContext();
        
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var serverTime = DateTime.Now;
                var localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Russian Standard Time");
                var line = db.Matches
                    .Include(x => x.MatchEvents)
                    .Where(m=> m.ChampionshipId == id &&  m.Date > localTime );

//                ViewBag.MatchesNotifierEntity = db.GetNotifierEntity<MatchEvent>(db.MatchEvents).ToJson();
                ViewBag.MatchEventsNotifierEntity = db.GetNotifierEntity<MatchEvent>(db.MatchEvents).ToJson();
                ViewBag.ChampId = id;
                ViewBag.Title ="Линия - "+db.Championships.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
                return View(line.ToList());
            }
        }

        public ActionResult RenderTable(int? id)
        {
            var line = db.Matches
                .Include(x => x.MatchEvents)
                .Where(m => m.Date > DateTime.Now && m.ChampionshipId == id);

            ViewBag.NotifierEntity = db.GetNotifierEntity<Match>(line).ToJson();
            return PartialView("_LineTable", line.ToList());
        }
        
    }

}