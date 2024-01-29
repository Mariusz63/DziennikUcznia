using NowyDziennik.Manager;
using System.Web.Mvc;
using NowyDziennik.Models;

namespace NowyDziennik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;
            return RedirectToAction("Index", "Home", new { language = lang });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}