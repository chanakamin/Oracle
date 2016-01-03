using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Oracle
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //name: "Application1Override",
            //url: "#/Recipe/{action}",
            //defaults: new { controller = "Recipe", action = "Index" }
            //  );

            routes.MapRoute(
               name: "angular",
               url: "#/{controller}/{action}/{id}",
               defaults: new { controller = "Recipe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Recipe", action = "createRecipe", id = UrlParameter.Optional }
            );

           
        }
    }
}