using NowyDziennik.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NowyDziennik.Controllers
{
    public class ClassTopicsController : Controller
    {
        private ApplicationDbContext db =ApplicationDbContext.Create();

        // GET: ClassTopics
        //public ActionResult Index()
        //{
        //    var classTopics = db.ClassTopics.Include(c => c.Class);
        //    return View(classTopics.ToList());
        //}

        public ActionResult Index(int? classId)
        {
            if (classId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Your logic to retrieve ClassTopics based on classId
            var classTopics = db.ClassTopics.Where(ct => ct.ClassId == classId.Value).ToList();

            return View(classTopics);
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

            // Create an instance of ClassTopicViewModel and pass it to the view
            var classTopicViewModel = new ClassTopicViewModel
            {
                ClassId = model.ClassId,
                Topic = model.Topic,
                Description = model.Description
            };

            return View(classTopicViewModel);
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
        public ActionResult Edit([Bind(Include = "ClassTopicId,Topic,Description,ClassId")] ClassTopic classTopic, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (file != null && file.ContentLength > 0)
                {
                    using (BinaryReader reader = new BinaryReader(file.InputStream))
                    {
                        // Read the file content into a byte array
                        classTopic.FileContent = reader.ReadBytes(file.ContentLength);
                    }
                }

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

        public ActionResult DownloadFile(int id)
        {
            ClassTopic classTopic = db.ClassTopics.Find(id);

            if (classTopic != null && classTopic.FileContent != null)
            {
                return File(classTopic.FileContent, "application/octet-stream", "FileName.ext");
            }

            // Handle case when file or ClassTopic is not found
            return HttpNotFound();
        }

    }
}
