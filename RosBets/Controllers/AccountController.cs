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

        //public ActionResult Login()
        //{
        //   return View();
        //}
        public ActionResult Registration(User User)
        {
            User test = null;
            if (ModelState.IsValid)
            {
                test = db.Users.FirstOrDefault(u => u.Mail == User.Mail);

                if (test == null)
                {
                    db.Users.Add(User);
                    db.SaveChanges();
                    test = db.Users.Where(u => u.Mail == User.Mail && u.Password == User.Password).FirstOrDefault();
                    if (test != null)
                    {
                        FormsAuthentication.SetAuthCookie(User.Mail, true);
                        return RedirectToAction("Index", "Account");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь уже существует");
            }
            return View(User);
        }

        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User test = null;
                test = db.Users.FirstOrDefault(u => u.Mail == user.Mail && u.Password == user.Password);
                if (test == null)
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Mail, true);
                    return RedirectToAction("Index", "Account");
                }
            }
            return View(user);
        }

        public string Index()
        {
            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }
            return result;
        }
    }
}