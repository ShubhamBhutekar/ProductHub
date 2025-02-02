namespace ProductHub.Migrations
{
    using ProductHub.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductHub.Models.ProductHubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductHub.Models.ProductHubDbContext context)
        {
            // Adding some initial categories
            Console.WriteLine("Seeding data...");
            context.Categories.AddOrUpdate(
                c => c.CategoryName,
                new Category { CategoryName = "Electronics" },
                new Category { CategoryName = "Clothing" },
                new Category { CategoryName = "Home Appliances" }
            );

            // Adding some initial products
            context.Products.AddOrUpdate(
                p => p.ProductName,
                new Product { ProductName = "Smartphone", CategoryId = 1 },
                new Product { ProductName = "Laptop", CategoryId = 1 },
                new Product { ProductName = "T-shirt", CategoryId = 2 }
            );

            // Save changes to the context
            context.SaveChanges();
            Console.WriteLine("Seeding completed.");
        }
    }
}
