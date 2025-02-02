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
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}