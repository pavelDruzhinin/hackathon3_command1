using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;

namespace RosBets.Controllers
{
    public class UserController : Controller
    {
        private RosBetsContext db = new RosBetsContext();

        // GET: User
        // Эту штуку можно оставить чтобы админы сайта могли смотреть списки пользователей
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); - это думаю здесь не нужно, но пока оставил
                //Если не введени Id пользователя то кидаем на логин ??
                return View("~/Views/Account/Login.cshtml");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Story(int? id)
        {
            //получаем Id юзера, если такого нет, то отсылаем на страницу логина 
            //если есть ищем все, что есть по базам
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); - это думаю здесь не нужно, но пока оставил
                //Если не введени Id пользователя то кидаем на логин ??
                return View("~/Views/Account/Login.cshtml");
            }
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }
 
            return View(user);
        }

        public ActionResult ChangePassword(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); - это думаю здесь не нужно, но пока оставил
                //Если не введени Id пользователя то кидаем на логин ??
                return View("~/Views/Account/Login.cshtml");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: User/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,FirstName,LastName,MiddleName,Mail,Phone,City,Password,Money")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}

        // GET: User/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,MiddleName,Mail,Phone,City,Password,Money")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        // GET: User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
