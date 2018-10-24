using System.Web.Mvc;
using System.Web.Routing;

namespace ExerciseProgram.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "Customers", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Exercises", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}