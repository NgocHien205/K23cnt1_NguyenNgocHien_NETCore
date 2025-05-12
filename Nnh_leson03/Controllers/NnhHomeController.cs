using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nnh_leson03.Models;

namespace Nnh_leson03.Controllers
{
    public class NnhHomeController : Controller
    {
        private readonly ILogger<NnhHomeController> _logger;

        public NnhHomeController(ILogger<NnhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NnhIndex()
        {
            return View();
        }

        public IActionResult NnhAbout()
        {
            ViewBag.about = "Ngọc Hiến";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NnhProfile()
        {
            return View();
        }
        public IActionResult NnhRazorcode()
        {
            return View();
        }
    }
}
