using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;

namespace RosBets.Controllers
{
    public class MoneyController : Controller
    {
        static RosBetsContext db = new RosBetsContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WorkWithMoney()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult WorkWithMoney(decimal Money,string action)
        {
            var user = db.Users.Where(u => u.Mail == User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (action == "put")
                {
                    user.Money += Money;
                    db.SaveChanges();
                }
                else
                if (Money <= user.Money && action == "pick")
                {
                    user.Money -= Money;
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Неверная сумма для вывода");
                }
            }
            return View(user);
        } 
    }
}