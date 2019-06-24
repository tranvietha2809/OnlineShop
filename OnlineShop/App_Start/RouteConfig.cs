using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MensProductIndex",
                url: "mens-product/",
                defaults: new { controller = "MensProduct", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "MensProductCategory",
                url: "mens-product/{metatitle}-{cateId}",
                defaults: new { controller = "MensProduct", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "mens-product/details/{metatile}-{productId}",
                defaults: new { controller = "MensProduct", action = "Details", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            
        }
    }
}
