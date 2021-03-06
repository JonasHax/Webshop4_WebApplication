﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication {

    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShoppingCart",
                url: "Cart/Add",
                defaults: new { controller = "Cart", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShoppingCart2",
                url: "Cart/Index",
                defaults: new { controller = "Cart", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "DeleteFromCart",
              url: "Cart/Delete",
              defaults: new { controller = "Cart", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "CheckOut",
              url: "CheckOut/Index",
              defaults: new { controller = "CheckOut", action = "Index" }
            );


        }
    }
}