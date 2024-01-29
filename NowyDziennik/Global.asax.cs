using System.Globalization;
using System.Threading;
using System.Web;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NowyDziennik
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.ClassSubjectRoutes(RouteTable.Routes);
            RouteConfig.DownloadFile(RouteTable.Routes);
            RouteConfig.ChangeLanguage(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            var languageSession = "en";
            if (context != null && context.Session != null)
            {
                languageSession = context.Session["lang"] != null ? context.Session["lang"].ToString() : "en";
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageSession);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(languageSession);
        }
    }
}
