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
    public class SubjectTopicsController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.Create();

        // GET: SubjectTopics
        public ActionResult Index(int? classId)
        {
            if (classId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subjectTopics = db.SubjectTopics.Where(ct => ct.SubjectId == classId.Value).ToList(); ;
            return View(subjectTopics.ToList());
        }

        // GET: SubjectTopics/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            SubjectTopic subjectTopic = db.SubjectTopics.Find(id);
            if (subjectTopic == null)
            {
                return HttpNotFound();
            }
            return View(subjectTopic);
        }

        // GET: SubjectTopics/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: SubjectTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectTopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                SubjectTopic subjectTopic = new SubjectTopic();

                // Handle file upload
                if (model.File != null && model.File.ContentLength > 0)
                {
                    using (BinaryReader reader = new BinaryReader(model.File.InputStream))
                    {
                        // Read the file content into a byte array
                        subjectTopic.FileContent = reader.ReadBytes(model.File.ContentLength);
                    }
                }

                // Assign ClassId
                subjectTopic.SubjectId = model.SubjectId;

                // Set other properties
                subjectTopic.Topic = model.Topic;
                subjectTopic.Description = model.Description;

                db.SubjectTopics.Add(subjectTopic);
                db.SaveChanges();
                return RedirectToAction("Details", "Subjects", new { id = model.SubjectId });
            }


            // Create an instance of ClassTopicViewModel and pass it to the view
            var subjectTopicViewModel = new SubjectTopicViewModel
            {
                ClassId = model.ClassId,
                Topic = model.Topic,
                Description = model.Description
            };


            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", model.SubjectId);
            return View(subjectTopicViewModel);
        }

        // GET: SubjectTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectTopic subjectTopic = db.SubjectTopics.Find(id);
            if (subjectTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectTopic.SubjectId);
            return View(subjectTopic);
        }

        // POST: SubjectTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectTopicId,Topic,Description,FileContent,SubjectId")] SubjectTopic subjectTopic, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (file != null && file.ContentLength > 0)
                {
                    using (BinaryReader reader = new BinaryReader(file.InputStream))
                    {
                        // Read the file content into a byte array
                        subjectTopic.FileContent = reader.ReadBytes(file.ContentLength);
                    }
                }

                db.Entry(subjectTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectTopic.SubjectId);
            return View(subjectTopic);
        }

        // GET: SubjectTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectTopic subjectTopic = db.SubjectTopics.Find(id);
            if (subjectTopic == null)
            {
                return HttpNotFound();
            }
            return View(subjectTopic);
        }

        // POST: SubjectTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectTopic subjectTopic = db.SubjectTopics.Find(id);
            db.SubjectTopics.Remove(subjectTopic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile(int id)
        {
            SubjectTopic classTopic = db.SubjectTopics.Find(id);

            if (classTopic != null && classTopic.FileContent != null)
            {
                return File(classTopic.FileContent, "application/octet-stream", "FileName.ext");
            }

            // Handle case when file or ClassTopic is not found
            return HttpNotFound();
        }

        // GET: SubjectTopics/CreateTest/5
        public ActionResult CreateTest(int? subjectTopicId)
        {
            if (subjectTopicId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SubjectTopic subjectTopic = db.SubjectTopics.Find(subjectTopicId);

            if (subjectTopic == null)
            {
                return HttpNotFound();
            }

            var test = new Test
            {
                SubjectTopicId = subjectTopic.SubjectId,
                TeacherId = "your_teacher_id", // You need to set the teacher ID based on your authentication mechanism.
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(1), // Set the end time as per your requirements.
            };

            return View(test);
        }

        // POST: SubjectTopics/CreateTest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTest(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Details", "SubjectTopics", new { id = test.SubjectTopicId });
            }

            // Handle validation errors
            return View(test);
        }

        // GET: SubjectTopics/AddQuestion/5
        public ActionResult AddQuestion(int? testId)
        {
            if (testId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Test test = db.Tests.Find(testId);

            if (test == null)
            {
                return HttpNotFound();
            }

            var question = new Question
            {
                TestId = testId.Value,
            };

            return View(question);
        }

        // POST: SubjectTopics/AddQuestion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Details", "SubjectTopics", new { id = question.Test.SubjectTopicId });
            }

            // Handle validation errors
            return View(question);
        }

        // GET: SubjectTopics/AddAnswer/5
        public ActionResult AddAnswer(int? questionId)
        {
            if (questionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(questionId);

            if (question == null)
            {
                return HttpNotFound();
            }

            var answer = new Answer
            {
                QuestionId = questionId.Value,
            };

            return View(answer);
        }

        // POST: SubjectTopics/AddAnswer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Details", "SubjectTopics", new { id = answer.Question.Test.SubjectTopicId });
            }

            // Handle validation errors
            return View(answer);
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
