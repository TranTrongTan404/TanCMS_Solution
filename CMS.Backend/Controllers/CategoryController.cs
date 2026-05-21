/* Ho va ten: Tran Trong Tan
 * MSSV: 2123110006
 * Ngay tao: 14/06/2026
 * Version: 1.0
 */
using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    // "Tiêm" kết nối vào Controller
    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Lấy dữ liệu THẬT từ bảng Categories trong SQL
        var data = _context.Categories.ToList();
        return View(data);
    }
}


