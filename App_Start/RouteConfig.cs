using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Product_management_arun
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "ShowList",
             url: "ShowList",
             defaults: new { controller = "Product", action = "Show", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "EditProduct",
             url: "EditProduct",
             defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "InsertProduct",
             url: "InsertProduct",
             defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
         );
            

            routes.MapRoute(
             name: "Login",
             url: "Login",
             defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "DashBoard",
               url: "DashBoard",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "signup",
                url: "Signup",
                defaults: new { controller = "Signup", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
