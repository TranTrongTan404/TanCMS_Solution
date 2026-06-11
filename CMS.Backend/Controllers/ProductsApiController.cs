using CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsApi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _context.Products
                    .AsNoTracking()
                    .Include(p => p.CategoryProduct)
                    .OrderByDescending(p => p.Id)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Price,
                        p.StockQuantity,
                        p.ImageUrl,
                        CategoryName = p.CategoryProduct.Name
                    })
                    .ToListAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi khi lấy danh sách sản phẩm.",
                    detail = ex.Message
                });
            }
        }

        // GET: api/ProductsApi/category/1
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            try
            {
                var products = await _context.Products
                    .AsNoTracking()
                    .Where(p => p.CategoryProductId == categoryId)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Price,
                        p.StockQuantity,
                        p.ImageUrl
                    })
                    .ToListAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi khi lọc sản phẩm.",
                    detail = ex.Message
                });
            }
        }

        // GET: api/ProductsApi/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .Include(p => p.CategoryProduct)
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.Price,
                        p.StockQuantity,
                        p.ImageUrl,
                        CategoryName = p.CategoryProduct.Name
                    })
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy sản phẩm này trong hệ thống."
                    });
                }

                return Ok(product);
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