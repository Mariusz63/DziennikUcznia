using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NowyDziennik.Models
{
    public class TestViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestViewModels
        public ActionResult Index()
        {
            return View(db.TestViewModels.ToList());
        }

        // GET: TestViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // GET: TestViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestViewModelId,Title,StartTime,EndTime,MaxPoints,SubjectId,TeacherId")] TestViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                db.TestViewModels.Add(testViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testViewModel);
        }

        // GET: TestViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // POST: TestViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestViewModelId,Title,StartTime,EndTime,MaxPoints,SubjectId,TeacherId")] TestViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testViewModel);
        }

        // GET: TestViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // POST: TestViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            db.TestViewModels.Remove(testViewModel);
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
