using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductHub.Models
{
    [Table("Products")]  // This ensures EF maps to the correct table
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        public virtual Category Category { get; set; }
    }
}