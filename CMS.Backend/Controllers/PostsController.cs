using Microsoft.AspNetCore.Mvc;
using CMS.Data;

namespace CMS.Backend.Controllers
{
    // Khi chạy:
    // https://localhost:xxxx/api/posts
    [Route("api/[controller]")]

    // Đánh dấu đây là API Controller
    [ApiController]

    // API dùng ControllerBase thay vì Controller
    public class PostsController : ControllerBase
    {
        // Kết nối Database
        private readonly ApplicationDbContext _context;

        // Constructor
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}