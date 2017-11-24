using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RosBets.Models;
using RosBets.Context;

namespace RosBets.Controllers
{
    public class AccountController : Controller
    {
        RosBetsContext db = new RosBetsContext();
        // GET: Account

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            User test = null;
            if (ModelState.IsValid)
            {
                test = db.Users.FirstOrDefault(u => u.Mail == user.Mail);

                if (test == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    test = db.Users.Where(u => u.Mail == user.Mail && u.Password == user.Password).FirstOrDefault();
                    if (test != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Mail, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь уже существует");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                User test = null;
                test = db.Users.FirstOrDefault(u => u.Mail == user.Login && u.Password == user.Password);
                if (test == null)
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    return View(user);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(user);
            }
        }
    }
}