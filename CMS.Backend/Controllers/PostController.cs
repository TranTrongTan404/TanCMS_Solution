using CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // /Post
        public IActionResult Index()
        {
            var posts = _context.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

            return View(posts);
        }

        // /Post/ListByCategory/2
        public IActionResult ListByCategory(int? id)
        {
            // 1. Kiểm tra id
            if (id == null)
            {
                return BadRequest("Vui lòng cung cấp mã danh mục.");
            }

            // 2. LINQ filter theo CategoryId
            var posts = _context.Posts
                .Where(p => p.CategoryId == id)
                .OrderByDescending(p => p.CreatedDate)
                .Include(p => p.Category)
                .ToList();

            // 3. Trả dữ liệu ra View
            return View("Index", posts);
        }

        // /Post/Details/5
        public IActionResult Details(int id)
        {
            var post = _context.Posts
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}