using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RosBets.Models;
using RosBets.Context;

namespace RosBets.Controllers
{
    public class AccountController : Controller
    {
        RosBetsContext db = new RosBetsContext();
        // GET: Account
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public JsonResult Register(User User)
        {
            
            db.Users.Add(User);
            db.SaveChanges();
            return new JsonResult {Data = User.Id};
        }

        public void Login(User user)
        {
            
        }
    }
}