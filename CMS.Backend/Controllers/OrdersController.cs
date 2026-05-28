using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách đơn hàng
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();

            return View(orders);
        }

        // Chi tiết đơn hàng
        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}