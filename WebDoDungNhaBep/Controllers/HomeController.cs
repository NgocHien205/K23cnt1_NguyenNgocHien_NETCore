using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDoDungNhaBep.Models;

namespace WebDoDungNhaBep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDoDungNhaBep02Context _context; // DbContext

        public HomeController(ILogger<HomeController> logger, ShopDoDungNhaBep02Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy danh sách sản phẩm kèm thông tin danh mục
            var sanPhams = _context.SanPhams
                            .Include(s => s.MaDanhMucNavigation)
                            .ToList();

            return View(sanPhams); // gửi sang View
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
