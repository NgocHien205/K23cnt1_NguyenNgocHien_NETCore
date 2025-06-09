using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nnhLesson08.Models;

namespace nnhLesson08.Controllers
{
    public class nnhHomeController : Controller
    {
        private readonly ILogger<nnhHomeController> _logger;

        public nnhHomeController(ILogger<nnhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
