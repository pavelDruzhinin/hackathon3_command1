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
            /*         ViewBag.Title="11";
         //заглушка для создания бд

                   var x =  db.Users.FirstOrDefault();*/
            var news = (from n in db.News
                        select n).FirstOrDefault();

            var sports = db.Sports.Include(y => y.Championships).ToList();
            MainViewModel mvm = new MainViewModel
            {
                SportList = sports,
                News = news
            };

            return View(mvm);
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

    // простой комментарий для гита
    //еще комментарий
}