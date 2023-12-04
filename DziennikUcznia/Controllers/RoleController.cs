using DziennikUcznia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DziennikUcznia.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public string Create()
        {
            IdentityManager im = new IdentityManager();

            im.CreateRole("Admin");
            im.CreateRole("Student");
            im.CreateRole("Teacher");
            im.CreateRole("Parent");

            return "OK";
        }


        public string AddToRole()
        {
            IdentityManager im = new IdentityManager();

           // im.AddUserToRoleByUsername("m.kopczynski@pb.edu.pl", "Admin");
           // im.AddUserToRoleByUsername("jan.kowalski@gmail.com", "User");

            return "OK";
        }
    }
}