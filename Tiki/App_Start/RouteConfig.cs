using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tiki
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetBooksByCompany",
                url: "cong-ty/{com_id}/{temp}",
                defaults: new { controller = "Book", action = "GetBooksByCompany", com_id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 name: "GetBooksByAuthor",
                 url: "tac-gia/{aut_id}/{temp}",
                 defaults: new { controller = "Book", action = "GetBooksByAuthor", aut_id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{book_id}",
                defaults: new { controller = "Book", action = "Index", book_id = UrlParameter.Optional },
                new string[] { "Tiki.Controllers" }
            );

        }
    }
}
