using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "AddDoctor", id = UrlParameter.Optional }
            );
            routes.MapRoute
                (
                name: "Sponsor",
                url: "{controller}/{action}/{id}",
                defaults : new { controller = "Sponsor",action = "SponsorLogin",id = UrlParameter.Optional }
            );
        }
    }
}
