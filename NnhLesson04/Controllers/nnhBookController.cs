using Microsoft.AspNetCore.Mvc;
using NnhLesson04.Models;

namespace NnhLesson04.Controllers
{
    public class nnhBookController : Controller
    {
        private List<nnhBook> nnhbooks = new List<nnhBook>
{
            new nnhBook
            {
                nnhId = "B001",
                nnhTitle = "Lập Trình C# Cơ Bản",
                nnhDescription = "Cuốn sách giới thiệu các kiến thức nền tảng về ngôn ngữ C# cho người mới bắt đầu.",
                nnhImage = "images/book1.jpg",
                nnhPrice = 150000f,
                nnhPage = 320
            },

            new nnhBook
            {
                nnhId = "B002",
                nnhTitle = "Cấu Trúc Dữ Liệu Và Giải Thuật",
                nnhDescription = "Giới thiệu các cấu trúc dữ liệu và thuật toán cơ bản cho sinh viên CNTT.",
                nnhImage = "images/book2.jpg",
                nnhPrice = 175000f,
                nnhPage = 400
            },

            new nnhBook
            {
                nnhId = "B003",
                nnhTitle = "Lập Trình Web Với ASP.NET",
                nnhDescription = "Hướng dẫn lập trình web động sử dụng ASP.NET Core và MVC.",
                nnhImage = "images/book3.jpg",
                nnhPrice = 180000f,
                nnhPage = 350
            },

             new nnhBook
            {
                nnhId = "B004",
                nnhTitle = "Cơ Sở Dữ Liệu",
                nnhDescription = "Trình bày các khái niệm cơ bản về hệ quản trị cơ sở dữ liệu và SQL.",
                nnhImage = "images/book4.jpg",
                nnhPrice = 160000f,
                nnhPage = 290
            },

            new nnhBook
            {
                nnhId = "B005",
                nnhTitle = "Nhập Môn Trí Tuệ Nhân Tạo",
                nnhDescription = "Giới thiệu các nguyên lý và ứng dụng cơ bản của trí tuệ nhân tạo.",
                nnhImage = "images/book5.jpg",
                nnhPrice = 200000f,
                nnhPage = 420
            },
        };
     

        //GET ://nnhBook/nnhIndex => lấy tất cả các cuốn sách
        public IActionResult nnhIndex()
        {
            //DUA du lieu len view
            return View(nnhbooks);
        }

        //GET ://nnhBook/nnhCreate
        public IActionResult nnhCreate()
        {
            nnhBook nnhBook = new nnhBook();    
            return View(nnhbooks);
        }
        //POST ://nnhBook/nnhCreateSubmit
        public IActionResult nnhCreateSubmit()
        {

            return RedirectToAction("nnhIndex");
        }

        //GET ://nnhBook/nnhEdit
        public IActionResult nnhEdit(string Id)
        {
           return View();   
        }
        //POST ://nnhBook/nnhEditSubmit
        public IActionResult nnhEditSubmit()
        {

            return RedirectToAction("nnhIndex");
        }
    }
}
