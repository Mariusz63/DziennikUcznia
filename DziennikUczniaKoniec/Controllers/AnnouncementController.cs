using DziennikUczniaKoniec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace DziennikUczniaKoniec.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext Db = ApplicationDbContext.Create();

        // GET: GlobalAnnouncement
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(Db.GlobalAnnouncement.ToArray());
        }

        // GET: GlobalAnnouncement/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var ga = Db.GlobalAnnouncement.Where(e => e.AnnouncementId == id).Single();
            return View(ga);
        }

        // GET: GlobalAnnouncement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlobalAnnouncement/Create
        [HttpPost]
        public ActionResult Create(Announcement announcement)
        {
            if (ModelState.IsValid == false)
                return View();
            announcement.CreationTime = DateTime.Now;
            announcement.AuthorId = User.Identity.GetUserId();
            Db.GlobalAnnouncement.Add(announcement);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: GlobalAnnouncement/Edit/5
        public ActionResult Edit(int id)
        {
            var ga = Db.GlobalAnnouncement.Where(e => e.AnnouncementId == id).Single();
            return View(ga);
        }

        // POST: GlobalAnnouncement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Announcement announcement)
        {
            if (ModelState.IsValid == false)
                return View();
            var record = Db.GlobalAnnouncement.Where(e => e.AnnouncementId == id).Single();
            record.Content = announcement.Content;
            record.CreationTime = DateTime.Now;
            record.AuthorId = User.Identity.GetUserId();
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: GlobalAnnouncement/Delete/5
        public ActionResult Delete(int id)
        {
            var ga = Db.GlobalAnnouncement.Where(e => e.AnnouncementId == id).Single();
            Db.GlobalAnnouncement.Remove(ga);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}