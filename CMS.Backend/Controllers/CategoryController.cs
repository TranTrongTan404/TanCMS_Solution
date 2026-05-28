/* Ho va ten: Tran Trong Tan
 * MSSV: 2123110006
 * Ngay tao: 14/06/2026
 * Version: 1.0
 */

using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // "Tiêm" kết nối vào Controller
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách danh mục
        public IActionResult Index()
        {
            // Lấy dữ liệu THẬT từ bảng Categories trong SQL
            var data = _context.Categories.ToList();

            return View(data);
        }

        // =========================
        // CREATE
        // =========================

        // GET: Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public IActionResult Create(Category model)
        {
            // BƯỚC 1:
            // Đưa dữ liệu vào bộ nhớ tạm của EF Core
            _context.Categories.Add(model);

            // BƯỚC 2:
            // Ghi dữ liệu thật vào SQL Server
            _context.SaveChanges();

            // Quay về trang danh sách
            return RedirectToAction("Index");
        }

        // =========================
        // EDIT
        // =========================

        // GET: Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Tìm dữ liệu theo Id
            var category = _context.Categories.Find(id);

            // Nếu không tìm thấy
            if (category == null)
            {
                return NotFound();
            }

            // Gửi dữ liệu sang View
            return View(category);
        }

        // POST: Category/Edit
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            // Cập nhật dữ liệu vào bộ nhớ tạm
            _context.Categories.Update(model);

            // Lưu thật xuống SQL Server
            _context.SaveChanges();

            // Quay lại danh sách
            return RedirectToAction("Index");
        }

        // =========================
        // DELETE
        // =========================

        // GET: Category/Delete/5
        public IActionResult Delete(int id)
        {
            // Tìm danh mục theo Id
            var category = _context.Categories.Find(id);

            // Nếu tồn tại thì xóa
            if (category != null)
            {
                // Đánh dấu xóa
                _context.Categories.Remove(category);

                // Xóa thật trong SQL Server
                _context.SaveChanges();
            }

            // Quay lại danh sách
            return RedirectToAction("Index");
        }
    }
}