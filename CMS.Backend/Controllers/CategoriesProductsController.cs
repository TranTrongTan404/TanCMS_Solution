using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class CategoriesProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // INDEX
        // =========================

        public IActionResult Index()
        {
            var categoriesProducts = _context.CategoryProducts.ToList();

            return View(categoriesProducts);
        }

        // =========================
        // DETAILS
        // =========================

        public IActionResult Details(int id)
        {
            var categoryProduct = _context.CategoryProducts.Find(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // =========================
        // CREATE
        // =========================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryProduct model)
        {
            _context.CategoryProducts.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // EDIT
        // =========================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoryProduct = _context.CategoryProducts.Find(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        [HttpPost]
        public IActionResult Edit(CategoryProduct model)
        {
            _context.CategoryProducts.Update(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // DELETE
        // =========================

        public IActionResult Delete(int id)
        {
            var categoryProduct = _context.CategoryProducts.Find(id);

            if (categoryProduct != null)
            {
                _context.CategoryProducts.Remove(categoryProduct);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}