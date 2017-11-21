using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;

namespace RosBets.Controllers
{
    public class HomeController : Controller
    {

        RosBetsContext db = new RosBetsContext();


        public ActionResult Index()
        {
            ViewBag.Title="11";
//заглушка для создания бд

           //var x =  db.Users.FirstOrDefault();
           return View();
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
    }    
    // простой комментарий для гита
    //еще комментарий
}