using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Com.Jamim.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var route = routes.MapRoute(
                  name: "Default",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Location", action = "Index", id = UrlParameter.Optional }
              );
            //  route.DataTokens["area"] = "Customer";

            //routes.MapRoute(
            //     name: "GetRegion",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "Location", action = "GetRegions", id = UrlParameter.Optional }
            // );
            route.DataTokens["area"] = "Customer";
        }
    }
}
