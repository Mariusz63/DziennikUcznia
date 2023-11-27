using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DziennikUczniaV3.Models;
using System.Web.Security;

namespace DziennikUczniaV3.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ClassController : Controller
    {
        private DziennikDbContext db = new DziennikDbContext();

        // GET: Class
        public ActionResult Index(ApplicationUser user)
        {
            // Pobierz role użytkownika
            var role = db.Users.Where(c => c.Role.Equals("Teacher"));

            if (role != null)
            {
              //  var classes = db.Classes.Where(c => c.Teachers.Any(t => t.TeacherId == teacher.TeacherId)).ToList();
              //  return View(classes);
            }

            return View(new List<Class>());
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@class);
        }

        // GET: Class/AddStudent/5
        public ActionResult AddStudent(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var @class = db.Classes.Find(id);

            if (@class == null)
            {
                return HttpNotFound();
            }

            var students = db.Students.ToList();
            ViewBag.Students = students;

            return View(@class);
        }

        // POST: Class/AddStudent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(int id, int studentId)
        {
            var @class = db.Classes.Find(id);

            if (@class == null)
            {
                return HttpNotFound();
            }

            var student = db.Students.Find(studentId);

            if (student != null)
            {
                @class.Students.Add(student);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
