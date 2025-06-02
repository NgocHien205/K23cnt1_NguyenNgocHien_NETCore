using Microsoft.AspNetCore.Mvc;
using nnhLesson07.Models;

namespace nnhLesson07.Controllers
{
    public class nnhEmployeeController : Controller
    {
        private static List<nnhEmployee> nnhListEmployee = new List<nnhEmployee>()
        {
            new nnhEmployee { NnhId = "2310900033", NnhName = "Nguyễn Ngọc Hiến", NnhBirthDay = new DateTime(2005, 06, 13), NnhEmail = "ngochien@gmail.com", NnhPhone = "0336076551", NnhSalary = 1000000, NnhStatus = true },
            new nnhEmployee { NnhId = "2", NnhName = "Trần Văn B", NnhBirthDay = new DateTime(1993, 05, 05), NnhEmail = "b@gmail.com", NnhPhone = "0902222222", NnhSalary = 1200, NnhStatus = false },
            new nnhEmployee { NnhId = "3", NnhName = "Lê Thị C", NnhBirthDay = new DateTime(1990, 07, 07), NnhEmail = "c@gmail.com", NnhPhone = "0903333333", NnhSalary = 900, NnhStatus = true },
            new nnhEmployee { NnhId = "4", NnhName = "Phạm Văn D", NnhBirthDay = new DateTime(1992, 02, 02), NnhEmail = "d@gmail.com", NnhPhone = "0904444444", NnhSalary = 950, NnhStatus = false },
            new nnhEmployee { NnhId = "5", NnhName = "Nguyễn Nhật Huy", NnhBirthDay = new DateTime(2003, 12, 12), NnhEmail = "nnhuy@gmail.com", NnhPhone = "0912345678", NnhSalary = 1500, NnhStatus = true }
        };
        public IActionResult nnhIndex()
        {
            return View(nnhListEmployee);
        }
        public IActionResult nnhCreate()
        {
            var model = new nnhEmployee();
            return View(model);
        }
    }
}
