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
        private ApplicationDbContext db =ApplicationDbContext.Create();

        // GET: Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(c => c.Teacher);
            return View(classes.ToList());
        }


        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Class @class = db.Classes.Include(c => c.Teacher)
            //                        .Include(c => c.ClassSubjects.Select(cs => cs.Subject))
            //                        .FirstOrDefault(c => c.ClassId == id);
            Class @class = db.Classes.Include(c => c.ClassSubjects).SingleOrDefault(c => c.ClassId == id);


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

        // GET: Classes/AddSubject/5
        public ActionResult AddSubject(int? id)
        {

            Class @class = db.Classes.Find(id);

            if (@class == null)
            {
                return HttpNotFound();
            }

            // Load the list of all subjects
            ViewBag.AllSubjects = new SelectList(db.Subjects, "SubjectId", "SubjectName");

            return View(new ClassSubject { ClassId = @class.ClassId });
        }


        // POST: Classes/AddSubject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubject([Bind(Include = "ClassSubjectId,Topic,Description,ClassId")] ClassSubject classSubject)
        {
            if (ModelState.IsValid)
            {
                db.ClassSubjects.Add(classSubject);
                db.SaveChanges();

                // Redirect to the CreateSubject action of the SubjectsController with the ClassId parameter
                return RedirectToAction("Create", "Subjects", new { classId = classSubject.ClassId });
            }

            return View(classSubject);
        }


        // Modify the existing Edit action to include ViewBag.AllSubjects
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class @class = db.Classes.Include(c => c.StudentClasses.Select(sc => sc.Student))
                .Include(c => c.ClassSubjects.Select(cs => cs.Subject))
                .FirstOrDefault(c => c.ClassId == id);

            if (@class == null)
            {
                return HttpNotFound();
            }

            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);

            // Load the list of all students
            ViewBag.AllStudents = new MultiSelectList(db.Students, "StudentId", "StudentId", @class.StudentClasses.Select(sc => sc.StudentId));

            // Load the list of all subjects
            ViewBag.AllSubjects = new MultiSelectList(db.Subjects, "SubjectId", "SubjectName", @class.ClassSubjects.Select(cs => cs.SubjectId));

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
                // Update class properties
                db.Entry(@class).State = EntityState.Modified;

                // Update the students associated with the class
                UpdateClassStudents(@class.ClassId, selectedStudents);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupervisorId = new SelectList(db.Teachers, "TeacherId", "TeacherId", @class.SupervisorId);

            // Reload the list of all students
            ViewBag.AllStudents = new SelectList(db.Students, "StudentId", "StudentId");

            return View(@class);
        }

        private void UpdateClassStudents(int classId, string[] selectedStudents)
        {
            // Get the existing students for the class
            var existingStudents = db.StudentClass.Where(sc => sc.ClassId == classId).ToList();

            // Remove students not selected in the edit form
            foreach (var existingStudent in existingStudents)
            {
                if (selectedStudents == null || !selectedStudents.Contains(existingStudent.StudentId))
                {
                    db.StudentClass.Remove(existingStudent);
                }
            }

            // Add new students selected in the edit form
            if (selectedStudents != null)
            {
                foreach (var studentId in selectedStudents)
                {
                    if (!existingStudents.Any(sc => sc.StudentId == studentId))
                    {
                        db.StudentClass.Add(new StudentClass { ClassId = classId, StudentId = studentId });
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

        // GET: Classes/CreateSubject
        public ActionResult CreateSubject()
        {
            return View();
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
