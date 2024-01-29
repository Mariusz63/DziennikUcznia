using Microsoft.Ajax.Utilities;
using NowyDziennik.Manager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace NowyDziennik.Controllers
{
    public class LanguageController : Controller
    {


            public ActionResult Switch(string culture)
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                return RedirectToAction("Index", "Home"); // Redirect to the homepage or the previous page
            }

        public JsonResult GetLocalizedStrings(string language)
        {
            // Load localized strings from resource files
            var localizedStrings = new
            {
                //WelcomeMessage = Resources.Localization.WelcomeMessage,
                // Add other localized strings here
            };

            return Json(localizedStrings, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelectEnglish()
        {
            LanguageCookie.Save(Response.Cookies, 0);
            return RedirectToAction("Index", "Announcements");
        }

        public ActionResult SelectPolish()
        {
            LanguageCookie.Save(Response.Cookies, 1);
            return RedirectToAction("Index", "Announcements");
        }  
        
        public ActionResult SelectRussian()
        {
            LanguageCookie.Save(Response.Cookies, 2);
            return RedirectToAction("Index", "Announcements");
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LanguageMang.GetDefaultLanguage();
                }
            }
            new LanguageMang().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }
    }
}