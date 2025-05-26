using Microsoft.AspNetCore.Mvc;
using nnhLesson06.Models.DataModels;
using System;
using System.Collections.Generic;

namespace nnhLesson06.Controllers
{
    public class NnhEmployeeController : Controller
    {
        private static List<NnhEmployee> nnhListEmployee = new List<NnhEmployee>()
        {
            new NnhEmployee { NnhId = "1", NnhName = "Nguyễn Ngọc Hiến", NnhBirthDay = new DateTime(2005, 06, 13), NnhEmail = "ngochien@gmail.com", NnhPhone = "0336076551", NnhSalary = 1000000, NnhStatus = true },
            new NnhEmployee { NnhId = "2", NnhName = "Trần Văn B", NnhBirthDay = new DateTime(1993, 05, 05), NnhEmail = "b@gmail.com", NnhPhone = "0902222222", NnhSalary = 1200, NnhStatus = false },
            new NnhEmployee { NnhId = "3", NnhName = "Lê Thị C", NnhBirthDay = new DateTime(1990, 07, 07), NnhEmail = "c@gmail.com", NnhPhone = "0903333333", NnhSalary = 900, NnhStatus = true },
            new NnhEmployee { NnhId = "4", NnhName = "Phạm Văn D", NnhBirthDay = new DateTime(1992, 02, 02), NnhEmail = "d@gmail.com", NnhPhone = "0904444444", NnhSalary = 950, NnhStatus = false },
            new NnhEmployee { NnhId = "SV01", NnhName = "Nguyễn Nhật Huy", NnhBirthDay = new DateTime(2003, 12, 12), NnhEmail = "nnhuy@gmail.com", NnhPhone = "0912345678", NnhSalary = 1500, NnhStatus = true }
        };

        // GET: Hiển thị danh sách nhân viên
        public IActionResult NnhIndex()
        {
            ViewBag.nnhListEmployee = nnhListEmployee;
            return View();
        }

        // GET: Hiển thị form tạo nhân viên mới
        [HttpGet]
        public IActionResult NnhCreate(NnhEmployee employee)

        {
            return View();
        }

        [HttpPost] // hành động gọi ứng với method là POST
        public IActionResult NnhCreateSubmit(NnhEmployee employee)
        {
            //// Gán mã MemberId mới (kiểu Guid)
            //employee.NvkId = Guid.NewGuid().ToString();

            // Thêm đối tượng member vào danh sách
            nnhListEmployee.Add(employee);


            // Chuyển hướng về trang danh sách thành viên
            return RedirectToAction("NnhIndex");
        }

    }
}
