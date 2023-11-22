using DziennikUcznia.Models;
using System.Web.Mvc;

namespace DziennikUcznia.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // -=-=- Register -=-=

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

       

        // =-=-=- Login -=-=-

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //=-=- Forgot password =-=-

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

       
        // -=-==- Confirm Email =-=-

        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View();
        }
    }
}
