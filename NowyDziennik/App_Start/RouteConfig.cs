using System.Web.Mvc;
using System.Web.Routing;

namespace NowyDziennik
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public static void ClassSubjectRoutes(RouteCollection routes)
        {
                        routes.MapRoute(
              name: "Subjects",
              url: "Subjects/{action}/{id}",
              defaults: new { controller = "Subjects", action = "Index", id = UrlParameter.Optional }
            );
        }  
        
        public static void ChangeLanguage(RouteCollection routes)
        {

            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public static void DownloadFile(RouteCollection routes)
        {
            routes.MapRoute(
            name: "DownloadFile",
            url: "ClassTopics/DownloadFile/{id}",
            defaults: new { controller = "ClassTopics", action = "DownloadFile" }
             );

        }
    }
}
