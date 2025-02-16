using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace ProductHub.Models
{
    public class ProductHubDbContext : DbContext
    {
        public ProductHubDbContext() : base("ProductHubConnection")
        {
            // Enable logging of SQL queries and errors
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}