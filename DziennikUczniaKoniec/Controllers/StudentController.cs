﻿using DziennikUczniaKoniec.Models;
using DziennikUczniaKoniec.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DziennikUczniaKoniec.Controllers
{
    [Authorize, ViewFilter]
    public class StudentController : Controller
    {
        private ApplicationDbContext Db = ApplicationDbContext.Create();

        // GET
        public ActionResult Index()
        {
            return new HttpNotFoundResult("Index does not exist.");
        }

        public ActionResult Details(string id)
        {
            return View(Db.Student.Where(e => e.Id == id).Single());
        }
    }
}