// Services/CategoryService.cs
using ProductHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductHub.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductHubDbContext _context;

        public CategoryService(ProductHubDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}