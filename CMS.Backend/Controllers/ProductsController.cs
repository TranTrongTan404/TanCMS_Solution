using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // =========================
        // INDEX
        // =========================

        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.CategoryProduct)
                .OrderByDescending(p => p.Id)
                .ToList();

            return View(products);
        }

        // =========================
        // DETAILS
        // =========================

        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.CategoryProduct)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // =========================
        // CREATE
        // =========================

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList =
                new SelectList(
                    _context.CategoryProducts,
                    "Id",
                    "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model, IFormFile? ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string uploadsFolder =
                    Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(ImageFile.FileName);

                string filePath =
                    Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }

            _context.Products.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // EDIT
        // =========================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList =
                new SelectList(
                    _context.CategoryProducts,
                    "Id",
                    "Name",
                    product.CategoryProductId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model, IFormFile? ImageFile)
        {
            var oldProduct = _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == model.Id);

            if (oldProduct == null)
            {
                return NotFound();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                string uploadsFolder =
                    Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(ImageFile.FileName);

                string filePath =
                    Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }
            else
            {
                // Giữ ảnh cũ nếu không chọn ảnh mới
                model.ImageUrl = oldProduct.ImageUrl;
            }

            _context.Products.Update(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // DELETE
        // =========================

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}