using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NowyDziennik.Models;

namespace NowyDziennik.Controllers
{
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classes
        public ActionResult Index()
        {
           // var classes = db.Classes.Include(@ => @.Teacher);
            return View(db.Classes.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName,SupervisorId,Description")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Include(c => c.Students).SingleOrDefault(c => c.ClassId == id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);
            ViewBag.AllStudents = new MultiSelectList(db.Students, "StudentId", "User.UserName", @class.Students.Select(s => s.StudentId));
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName,SupervisorId,Description")] Class @class, string[] selectedStudents)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(@class).State = EntityState.Modified;
                UpdateClassStudents(@class.ClassId, selectedStudents);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);
            ViewBag.AllStudents = new MultiSelectList(db.Students, "StudentId", "User.UserName", selectedStudents);
            //ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);
            return View(@class);
        }

        private void UpdateClassStudents(int classId, string[] selectedStudents)
        {
            Class @class = db.Classes.Include(c => c.Students).SingleOrDefault(c => c.ClassId == classId);

            // Clear existing students
            @class.Students.Clear();

            // Add selected students
            if (selectedStudents != null)
            {
                foreach (var studentId in selectedStudents)
                {
                    Student student = db.Students.Find(studentId);
                    if (student != null)
                    {
                        @class.Students.Add(student);
                    }
                }
            }
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
