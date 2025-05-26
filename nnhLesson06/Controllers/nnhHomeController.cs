using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nnhLesson06.Models;

namespace nnhLesson06.Controllers
{
    public class nnhHomeController : Controller
    {
        private readonly ILogger<nnhHomeController> _logger;

        public nnhHomeController(ILogger<nnhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nnhIndex()
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
