using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RosBets.Models;
using RosBets.Context;
using System.Data.Entity;
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

                return RedirectToAction("Details", "Account");
            }
            return RedirectToAction("Index", "Home");
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

        [HttpPost]
        public JsonResult CategorySearch(string type, string results)
        {

            var existingUser = db.Users.FirstOrDefault(u => u.Mail == User.Identity.Name);

            var betResult = from betEvent in db.BetEvents
                            join _bet in db.Bets on betEvent.BetId equals _bet.Id
                            join match in db.Matches on betEvent.MatchId equals match.Id
                            join user in db.Users on _bet.UserId equals user.Id
                            join _event in db.Events on betEvent.EventId equals _event.Id
                            select new
                            {
                                Match = match.MatchName,
                                Date = match.Date,
                                Coefficient = _bet.TotalCoefficient,
                                Success = _bet.Success,
                                UserId = user.Id,
                                EventId = _event.Shortname,
                                BetEvents = _bet.BetEvents
                            };

            List<BetSearch> myListResult = new List<BetSearch>();

            if (results != "all")
            {
                if (type == "all" && results == "positive")
                {
                    
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.Success == true && b.BetEvents.Count >= 1
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "all" && results == "negative")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.Success == false && b.BetEvents.Count >= 1
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "all" && results == "awaiting")
                {
                  
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.Success == null && b.BetEvents.Count >= 1
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "express" && results == "all")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id &&  b.BetEvents.Count > 1
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "express" && results == "positive")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count > 1 && b.Success == true
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "express" && results == "negative")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count > 1 && b.Success == false
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "express" && results == "awaiting")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count > 1 && b.Success == null
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "ordinary" && results == "all")
                {
                   var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count == 1
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "ordinary" && results == "positive")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count == 1 && b.Success == true
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else if (type == "ordinary" && results == "negative")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count == 1 && b.Success == false
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }

                else //if (type == "ordinary" && results == "awaiting")
                {
                    var bet = from b in betResult
                              where b.UserId == existingUser.Id && b.BetEvents.Count == 1 && b.Success == null
                              select b;
                    foreach (var betRes in bet)
                    {
                        BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                        myListResult.Add(userSearch);
                    }

                    return new JsonResult { Data = myListResult };
                }
            }
            else if (results == "all" && type == "all")
            {
                var bet = from b in betResult
                          where b.UserId == existingUser.Id && b.BetEvents.Count >= 1 
                          select b;
                foreach (var betRes in bet)
                {
                    BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                    myListResult.Add(userSearch);
                }

                return new JsonResult { Data = myListResult };
            }

            else if (results == "all" && type == "ordinary")
            {
                var bet = from b in betResult
                          where b.UserId == existingUser.Id && b.BetEvents.Count == 1
                          select b;
                foreach (var betRes in bet)
                {
                    BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                    myListResult.Add(userSearch);
                }

                return new JsonResult { Data = myListResult };
            }

            else if (results == "all" && type == "express")
            {

                var bet = from b in betResult
                          where b.UserId == existingUser.Id && b.BetEvents.Count > 1
                          select b;
                foreach (var betRes in bet)
                {
                    BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                    myListResult.Add(userSearch);
                }

                return new JsonResult { Data = myListResult };
            }

            else
            {
                var bet = from b in betResult
                          where b.UserId == existingUser.Id && b.BetEvents.Count >= 1
                          select b;
                foreach (var betRes in bet)
                {
                    BetSearch userSearch = new BetSearch { Id = betRes.UserId, Date = betRes.Date, Success = betRes.Success, MatchName = betRes.Match, TotalCoefficient = betRes.Coefficient, Shortname = betRes.EventId };
                    myListResult.Add(userSearch);
                }

                return new JsonResult { Data = myListResult };
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();

            base.Dispose(disposing);
        }
    }
}