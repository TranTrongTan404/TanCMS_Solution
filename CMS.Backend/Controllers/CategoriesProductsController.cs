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

        public IActionResult Index()
        {
            var categoriesProducts = _context.CategoryProducts.ToList();

            return View(categoriesProducts);
        }

        public IActionResult Details(int id)
        {
            var categoryProduct = _context.CategoryProducts.Find(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }
    }
}