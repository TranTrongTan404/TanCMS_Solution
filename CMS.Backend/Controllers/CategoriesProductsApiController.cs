using CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesProductsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriesProductsApi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _context.CategoryProducts
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Description
                    })
                    .ToListAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi khi lấy danh mục sản phẩm.",
                    detail = ex.Message
                });
            }
        }

        // GET: api/CategoriesProductsApi/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var category = await _context.CategoryProducts
                    .AsNoTracking()
                    .Where(c => c.Id == id)
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Description
                    })
                    .FirstOrDefaultAsync();

                if (category == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy danh mục."
                    });
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi hệ thống.",
                    detail = ex.Message
                });
            }
        }
    }
}