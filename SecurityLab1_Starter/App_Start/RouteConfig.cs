using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "BlankURL",
            //    url: "",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "HomeRoute",
            //    url: "Home/{action}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    constraints: new { action = @"^Index$|^About$|^Contact$" }
            //);

            //routes.MapRoute(
            //    name: "InventoryRoute",
            //    url: "Inventory/{action}",
            //    defaults: new { controller = "Inventory", action = "Index" },
            //    constraints: new { action = @"^Index$" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                //constraints: new { controller = "Home|Inventory" }
            );

            //routes.MapRoute(
            //    name: "NotFound",
            //    url: "{*url}",
            //    defaults: new { controller = "Error", action = "Notfound" }
            //);
        }
    }
}
