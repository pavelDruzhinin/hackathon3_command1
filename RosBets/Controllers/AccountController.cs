using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RosBets.Models;
using RosBets.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

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
        public ActionResult Registration(RegUser user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Mail == user.Mail);

                if (existingUser == null)
                {
                    db.Users.Add(new User {
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    MiddleName=user.MiddleName,
                    Mail=user.Mail,
                    Phone=user.Phone,
                    City=user.City,
                    Password=user.Password,
                    });
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
        public ActionResult Details()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View(user);
        }

        [HttpGet]
        public ActionResult ChangePassword(int? id)
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

            else if (id == null) { return RedirectToAction("Login", "Account"); }

            else { RedirectToAction("Index", "Home"); }

            return RedirectToAction("Details", "Account");


        }

        //Временно внесено в комментарии
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
                
                if ((changePass.OldPassword == existingUser.Password) & (changePass.Id == existingUser.Id)) 
                {

                    if (changePass.NewPassword != changePass.ConfirmNewPassword)
                    {
                        ModelState.AddModelError("NewPassword", "Пароли не совпадают");
                        return View();
                    }
                    
                    existingUser.Password = changePass.NewPassword;
                    db.Entry(existingUser).State = EntityState.Modified;
                    try
                    {

                        db.SaveChanges();
                        return RedirectToAction("Details", "Account");

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            Response.Write("Object: " + validationError.Entry.Entity.ToString());
                            Response.Write("    ");
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                Response.Write(err.ErrorMessage + "    ");
                            }
                        }
                    }

                    
                    return RedirectToAction("Details", "Account");
                }

                ModelState.AddModelError("OldPassword", "Неверный пароль");
                return View();

            }
            //ModelState.AddModelError("NewPassword", "Пароли не совпадают");
            return View();
            
        }


        public ActionResult Story(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        
        public ActionResult CategorySearch(string type, string results)
        {


            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);

            List<Bet> bets = db.Bets
                .Where(x=>x.UserId == existingUser.Id)
                .Include(x=>x.BetEvents)
                .Include(x=>x.BetEvents.Select(e=>e.BetEventStatus))
                .Include(x=>x.BetEvents.Select(e=>e.Event))
                .Include(x=>x.BetEvents.Select((b=>b.Match)))
                .Include(x=>x.BetEvents.Select(v=>v.Match.Championship))
                .ToList();
            switch (type)
            {
                case "ordinary":
                    bets = bets.Where(x => x.BetEvents.Count == 1).ToList();
                    break;
                case "express":
                    bets = bets.Where(x => x.BetEvents.Count > 1).ToList();
                    break;
            }

            switch (results)
            {
                case "positive":
                    bets = bets.Where(x => x.Success == true).ToList();
                    break;
                case "negative":
                    bets = bets.Where(x => x.Success == false).ToList();
                    break;
                case "awaiting":
                    bets = bets.Where(x => x.Success == null).ToList();
                    break;
            }

            return PartialView("_HistoryTable", bets);

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();

            base.Dispose(disposing);
        }
    }
}