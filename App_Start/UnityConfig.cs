using ProductHub.Models;
using ProductHub.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductHub
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();

            // Register your DbContext
            container.RegisterType<ProductHubDbContext>();
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}