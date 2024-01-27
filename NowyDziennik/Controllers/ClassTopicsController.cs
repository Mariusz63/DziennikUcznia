using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NowyDziennik.Models;

namespace NowyDziennik.Controllers
{
    public class ClassTopicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassTopics
        public ActionResult Index()
        {
            var classTopics = db.ClassTopics.Include(c => c.Class);
            return View(classTopics.ToList());
        }

        // GET: ClassTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTopic classTopic = db.ClassTopics.Find(id);
            if (classTopic == null)
            {
                return HttpNotFound();
            }
            return View(classTopic);
        }

        // GET: ClassTopics/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: ClassTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ClassTopicId,Topic,Description,ClassId")] ClassTopic classTopic)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ClassTopics.Add(classTopic);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", classTopic.ClassId);
        //    return View(classTopic);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassTopicViewModel model)
        {
            if (model.ClassId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                // Instantiate a new ClassTopic object
                ClassTopic classTopic = new ClassTopic();

                // Handle file upload
                if (model.File != null && model.File.ContentLength > 0)
                {
                    using (BinaryReader reader = new BinaryReader(model.File.InputStream))
                    {
                        // Read the file content into a byte array
                        classTopic.FileContent = reader.ReadBytes(model.File.ContentLength);
                    }
                }

                // Assign ClassId
                classTopic.ClassId = model.ClassId;

                // Set other properties
                classTopic.Topic = model.Topic;
                classTopic.Description = model.Description;

                // Save ClassTopic to the database
                db.ClassTopics.Add(classTopic);
                db.SaveChanges();

                // Redirect to the Details action of the ClassesController with the ClassId parameter
                return RedirectToAction("Details", "Classes", new { id = model.ClassId });
            }

            // If model state is not valid, repopulate the SelectList for ClassId
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");

            return View(model);
        }





        // GET: ClassTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTopic classTopic = db.ClassTopics.Find(id);
            if (classTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", classTopic.ClassId);
            return View(classTopic);
        }

        // POST: ClassTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassTopicId,Topic,Description,ClassId")] ClassTopic classTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", classTopic.ClassId);
            return View(classTopic);
        }

        // GET: ClassTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTopic classTopic = db.ClassTopics.Find(id);
            if (classTopic == null)
            {
                return HttpNotFound();
            }
            return View(classTopic);
        }

        // POST: ClassTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassTopic classTopic = db.ClassTopics.Find(id);
            db.ClassTopics.Remove(classTopic);
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
