using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NowyDziennik.Models;

namespace NowyDziennik.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.Create();

        // GET: Messages
        //public ActionResult Index()
        //{
        //    // Get the currently logged-in user
        //    var currentUser = db.Users.Find(User.Identity.GetUserId());

        //    // Retrieve messages where the current user is the sender or receiver
        //    var messages = db.Messages
        //        .Include(m => m.Sender)
        //        .Where(m => m.SenderId == currentUser.Id || m.RecipientId == currentUser.Id);

        //    return View(messages.ToList());
        //}

        public ActionResult Index()
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());

            var sentMessages = db.Messages
                .Include(m => m.Recipient)
                .Where(m => m.SenderId == currentUser.Id)
                .ToList();

            var receivedMessages = db.Messages
                .Include(m => m.Sender)
                .Where(m => m.RecipientId == currentUser.Id)
                .ToList();

            var viewModel = new CombinedMessagesViewModel
            {
                SentMessages = sentMessages,
                ReceivedMessages = receivedMessages
            };

            return View(viewModel);
        }


        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            var users = db.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FirstName + " " + u.LastName
                })
                .ToList();

            ViewBag.Users = users;

            return View();
        }

         // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageViewModel messageViewModel, HttpPostedFileBase file)
        {
            messageViewModel.SenderId = User.Identity.GetUserId();


                // Handle file upload
                if (file != null && file.ContentLength > 0)
                {
                    var fileType = new FileType
                    {
                        Name = Path.GetFileName(file.FileName),
                        Data = new byte[file.ContentLength]
                    };

                    using (var reader = new BinaryReader(file.InputStream))
                    {
                        fileType.Data = reader.ReadBytes(file.ContentLength);
                    }

                    db.FileTypes.Add(fileType);
                    db.SaveChanges();

                    messageViewModel.FileTypeId = fileType.FileTypeId;
                }
                // Set the SenderId to the currently logged-in user


                var message = new Message
                {
                    Content = messageViewModel.Content,
                    DateTime = DateTime.Now,
                    SenderId = messageViewModel.SenderId,
                    RecipientId = messageViewModel.RecipientId,  
                    FileTypeId = messageViewModel.FileTypeId 
                };

                db.Messages.Add(message);
                db.SaveChanges();

               // return RedirectToAction("Index");
            

            ViewData["Users"] = new SelectList(db.Users, "Id", "UserName");
            //ViewData["SenderId"] = new SelectList(db.Users, "Id", "FirstName", messageViewModel.SenderId);
            //ViewBag.SenderId = new SelectList(db.Users, "Id", "FirstName", messageViewModel.SenderId);
            return View(messageViewModel);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.SenderId = new SelectList(db.Users, "Id", "FirstName", message.SenderId);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,Content,DateTime,SenderId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SenderId = new SelectList(db.Users, "Id", "FirstName", message.SenderId);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
