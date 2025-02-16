// Services/ProductService.cs
using ProductHub.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace ProductHub.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductHubDbContext _context;

        public ProductService(ProductHubDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}