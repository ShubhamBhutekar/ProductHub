using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ProductHub.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation property for Products
        public virtual ICollection<Product> Products { get; set; }
    }
}