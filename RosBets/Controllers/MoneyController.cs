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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal? Money,string action)
        { 
            var user = db.Users.Where(u => u.Mail == User.Identity.Name).FirstOrDefault();
            if (Money != null)
            {
                if (Money > 0) {
                    if (ModelState.IsValid)
                    {
                        if (action == "put")
                        {
                            user.Money += (decimal)Money;
                            db.SaveChanges();
                        }
                        else
                        if (Money <= user.Money && action == "pick")
                        {
                            user.Money -= (decimal)Money;
                            db.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Неверная сумма для вывода");
                        }
                    }
                }
                else { ModelState.AddModelError("", "Введено отрицательное число"); }
            }
            else { ModelState.AddModelError("", "Введены некорректные символы"); }
            return View(user);
        } 
    }
}