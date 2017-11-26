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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Mail == user.Login && u.Password == user.Password);
                if (existingUser == null)
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



        public ActionResult Registration()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Mail == user.Mail);

                if (existingUser == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Mail, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким e-mail уже существует");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);

            if(id == existingUser.Id)
            {
                return View(existingUser);
            }

            return View(existingUser);
        }

        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);
            var changePass = new ChangePass { Id = existingUser.Id, Mail = existingUser.Mail };

            if (id == existingUser.Id)
            {
                return View(changePass);
            }

            return RedirectToAction("Details", "Account");


        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePass changePass)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);
                
                if ((changePass.OldPassword == existingUser.Password) & (changePass.Id == existingUser.Id) & (changePass.Mail== existingUser.Mail))
                {
                    /////////////////////////////////////////////////////
                    /////// Как поменять значения в базе данных ? ///////
                    /////////////////////////////////////////////////////
                    db.Users.Remove(existingUser);
                    existingUser.Password = changePass.NewPassword;
                    db.Users.Add(existingUser);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Account");
                }

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();

            base.Dispose(disposing);
        }
    }
}