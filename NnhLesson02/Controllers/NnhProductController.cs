using Microsoft.AspNetCore.Mvc;

namespace NnhLesson02.Controllers
{
    public class NnhProductController : Controller
    {
        public IActionResult NnhIndex()
        {
            ViewData["messageVD"] = "Du lieu tu viewData";
            ViewBag.messageVB = "Du lieu tu viewBag";
            TempData["messageTD"] = "Du lieu tu TempData";
            return View();
        }
        
       
    }
}
