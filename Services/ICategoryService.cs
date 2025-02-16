// Services/ICategoryService.cs
using ProductHub.Models;
using System.Collections.Generic;

namespace ProductHub.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        void AddCategory(Category category);
    }
}