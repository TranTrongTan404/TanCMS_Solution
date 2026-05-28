using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách chi tiết đơn hàng
        public IActionResult Index()
        {
            var orderDetails = _context.OrderDetails.ToList();

            return View(orderDetails);
        }

        // Chi tiết 1 dòng order detail
        public IActionResult Details(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }
    }
}