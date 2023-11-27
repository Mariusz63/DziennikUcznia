using DziennikUczniaV3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DziennikUczniaV3.Controllers
{
    public class AccountController : Controller
    {

        private DziennikDbContext db = new DziennikDbContext();

        // GET: Account
        public ActionResult Index()
        {
            var query = db.Users;

            return View(query.ToList());
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var query = user.FirstName;
            ViewBag.List = query.ToList();

            return View(user);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName, LastName,Role,BirthDate,Email,MobileNo,Password")] ApplicationUser user)
        {
            // Tworzenie nowego użytkownika
            ApplicationUser newUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Role = user.Role,
                MobileNo = user.MobileNo,
                Password = user.Password
            };

            // Sprawdzenie, czy użytkownik o podanym UserId już istnieje
            var existingUser = db.Users.SingleOrDefault(u => u.UserId == newUser.UserId);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Użytkownik o podanym UserId już istnieje");
                return View(user);
            }

            // Dodanie nowego użytkownika do bazy danych
            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,Name")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUser company = db.Users.Find(id);
            db.Users.Remove(company);
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
