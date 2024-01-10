using DziennikUczniaKoniec.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DziennikUczniaKoniec.Controllers
{
    public class GradesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grades
        public ActionResult Index()
        {
            var grades = db.Grade.Include(g => g.Student).Include(g => g.Subject).Include(g => g.Teacher);
            return View(grades.ToList());
        }

        // GET: Grades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "ParentId");
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName");
            ViewBag.TeacherId = new SelectList(db.Teacher, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradeId,Value,Weight,Date,Comment,StudentId,TeacherId,SubjectId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Grade.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "ParentId", grade.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", grade.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "TeacherId", "TeacherId", grade.TeacherId);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "ParentId", grade.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", grade.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "TeacherId", "TeacherId", grade.TeacherId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradeId,Value,Weight,Date,Comment,StudentId,TeacherId,SubjectId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "ParentId", grade.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", grade.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "TeacherId", "TeacherId", grade.TeacherId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade grade = db.Grade.Find(id);
            db.Grade.Remove(grade);
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
