using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;
using RosBets.ViewModel;
using System.Data.Entity;

namespace RosBets.Controllers
{
    public class HomeController : Controller
    {

        RosBetsContext db = new RosBetsContext();


        public ActionResult Index()
        {
            var news = db.News.Max(x => x.Id);

            return View(news);
        }

        [ChildActionOnly]
        public ActionResult RenderLineSelect()
        {
            var sports = db.Sports.Include(y => y.Championships).ToList();
            return PartialView("left_column", sports);
        }

        [ChildActionOnly]
        public ActionResult RenderHeader()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return PartialView("Header");
            }
            var user = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
            string money = user.Money.ToString("0.00");
            return PartialView("Header", money);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Info()
        {
            ViewBag.Message = "Your info page.";

            return View();
        }
    }
    
}