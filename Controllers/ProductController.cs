using ProductHub.Models;
using ProductHub.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductHub.Controllers
{
    public class ProductController : Controller
    {
        private ProductHubDbContext db = new ProductHubDbContext();

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: Product
        public ActionResult Index(int? page)
        {
            var products1 = _productService.GetAllProducts();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var products = db.Products.Include(p => p.Category)
                                      .OrderBy(p => p.ProductId)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalRecords = db.Products.Count();
            return View(products);
        }

        private bool IsProductNameDuplicate(string productName, int? productId = null)
        {
            return db.Products.Any(p => p.ProductName == productName && p.ProductId != productId);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)

        {
            if (IsProductNameDuplicate(product.ProductName))
            {
                ModelState.AddModelError("ProductName", "A product with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    _productService.AddProduct(product);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Database Update Error: " + ex.InnerException?.Message);
                    ModelState.AddModelError("", "An error occurred while saving the product.");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (IsProductNameDuplicate(product.ProductName, product.ProductId))
            {
                ModelState.AddModelError("Name", "A product with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Database Update Error: " + ex.InnerException?.Message);
                    ModelState.AddModelError("", "An error occurred while updating the product.");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database Update Error: " + ex.InnerException?.Message);
                ModelState.AddModelError("", "An error occurred while deleting the product.");
            }
            return RedirectToAction("Index");
        }
    }
}
