using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace ProductHub
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default Route - Redirects to Product List
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );

            // Route for Paginated Product List
            routes.MapRoute(
                name: "ProductListPaginated",
                url: "Product/Page/{page}",
                defaults: new { controller = "Product", action = "Index", page = 1 },
                constraints: new { page = @"\d+" } // Ensures page is a number
            );

            // CRUD Routes for Product
            routes.MapRoute(
                name: "ProductCreate",
                url: "Product/Create",
                defaults: new { controller = "Product", action = "Create" }
            );

            routes.MapRoute(
                name: "ProductEdit",
                url: "Product/Edit/{id}",
                defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDelete",
                url: "Product/Delete/{id}",
                defaults: new { controller = "Product", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "Product/Details/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );

            // CRUD Routes for Category
            routes.MapRoute(
                name: "CategoryList",
                url: "Category/List",
                defaults: new { controller = "Category", action = "List" }
            );

            routes.MapRoute(
                name: "CategoryCreate",
                url: "Category/Create",
                defaults: new { controller = "Category", action = "Create" }
            );

            routes.MapRoute(
                name: "CategoryEdit",
                url: "Category/Edit/{id}",
                defaults: new { controller = "Category", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryDelete",
                url: "Category/Delete/{id}",
                defaults: new { controller = "Category", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryDetails",
                url: "Category/Details/{id}",
                defaults: new { controller = "Category", action = "Details", id = UrlParameter.Optional }
            );
        }
    }
}
