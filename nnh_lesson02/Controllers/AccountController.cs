using Microsoft.AspNetCore.Mvc;
using nnh_lesson02.Models;

namespace nnh_lesson02.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account
                {
                    Id = 1,
                    Name = "Nguyễn Ngọc Hiến",
                    Email = "nguyenhien@gmail.com",
                    Phone = "0336076551",
                    Address = "Thái Bình",
                    avatar = Url.Content("~/images/avatar/07.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 6, 13)
                },
                new Account
                {
                    Id = 2,
                    Name = "Nguyễn Văn B",
                    Email = "vanB@gmail.com",
                    Phone = "091234567",
                    Address = "Hà Nội",
                    avatar = Url.Content("~/images/avatar/05.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2004, 7, 15)
                },
                new Account
                {
                    Id = 3,
                    Name = "Văn Thị C",
                    Email = "ThiC@gmail.com",
                    Phone = "0976543123",
                    Address = "Hải Phòng",
                    avatar = Url.Content("~/images/avatar/02.jpg"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(2003, 12, 25)
                }
            };

            return View(accounts); // TRUYỀN DANH SÁCH
        }

        //
        [Route("ho-so-cua-toi",Name = "Profile")]
        public IActionResult Profile()
        {
            Account account = new Account
            {
                Id = 1,
                Name = "Nguyễn Ngọc Hiến",
                Email = "nguyenhien@gmail.com",
                Phone = "0336076551",
                Address = "Thái Bình",
                avatar = Url.Content("~/images/avatar/07.jpg"),
                Gender = 1,
                Bio = "My name is small",
                Birthday = new DateTime(2005, 6, 13)
            };

            return View(account); // TRUYỀN MỘT OBJECT
        }
    }
}
