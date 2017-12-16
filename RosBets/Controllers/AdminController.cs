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
    public class AdminController : Controller
    {
        private RosBetsContext db = new RosBetsContext();

        // GET: Admin
        [Authorize(Users = "admin@rosbets.ru")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Admin/Details/5
        [Authorize(Users = "admin@rosbets.ru")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Create
        [Authorize(Users = "admin@rosbets.ru")]
        public ActionResult Create()
        {
            return View();
        }     
        
        // GET: Admin/Delete/5
        [Authorize(Users = "admin@rosbets.ru")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@rosbets.ru")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
