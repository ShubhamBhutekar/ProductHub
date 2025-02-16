using ProductHub.Models;
using ProductHub.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductHub.Controllers
{
    public class CategoryController : Controller
    {
        private ProductHubDbContext db = new ProductHubDbContext();

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index(int? page)
        {
            var categories1 = _categoryService.GetAllCategories();
            int pageSize = 5; 
            int pageNumber = (page ?? 1); 

            
            int skip = (pageNumber - 1) * pageSize;

          
            var categories = db.Categories
                               .OrderBy(c => c.CategoryId) 
                               .Skip(skip)
                               .Take(pageSize)
                               .ToList();

            
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = db.Categories.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)ViewBag.TotalRecords / pageSize);

            return View(categories);
        }

    

        private bool IsCategoryNameDuplicate(string categoryName, int? categoryId = null)
        {
            return db.Categories.Any(c => c.CategoryName == categoryName && c.CategoryId != categoryId);
        }


        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (IsCategoryNameDuplicate(category.CategoryName))
            {
                ModelState.AddModelError("CategoryName", "A category with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (IsCategoryNameDuplicate(category.CategoryName, category.CategoryId))
            {
                ModelState.AddModelError("CategoryName", "A category with the same name already exists.");
            }
                if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}