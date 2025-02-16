// Services/IProductService.cs
using ProductHub.Models;
using System.Collections.Generic;

namespace ProductHub.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
    }
}
