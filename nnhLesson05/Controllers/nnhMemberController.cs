using Microsoft.AspNetCore.Mvc;
using nnhLesson05.Models.DataModels;


namespace nnhLesson05.Controllers
{
    public class nnhMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult nnhGetMember()
        {
            var NnhMember = new nnhMember();
            NnhMember.nnhMemberId = Guid.NewGuid().ToString();
            NnhMember.nnhUserName = "Ngọc Hiến";
            NnhMember.nnhFullName = "Nguyễn Ngọc Hiến";
            NnhMember.nnhPassword = "1234";
            NnhMember.nnhEmail = "ngochien@gmail.com";
            
            ViewBag.NnhMember = NnhMember;
            return View(NnhMember);
        }

       
        
            public static readonly List<nnhMember> nnhMembers = new List<nnhMember>()
    {
        new nnhMember{nnhMemberId = Guid.NewGuid().ToString(), nnhUserName = "Hiến", nnhFullName = "Nguyễn Ngọc Hiến", nnhPassword = "1234", nnhEmail = "ngochien@gmail.com"},
        new nnhMember{nnhMemberId = Guid.NewGuid().ToString(), nnhUserName = "member2", nnhFullName = "Thành viên 2", nnhPassword = "123456", nnhEmail = "tv2@gmail.com"},
        new nnhMember{nnhMemberId = Guid.NewGuid().ToString(), nnhUserName = "member3", nnhFullName = "Thành viên 3", nnhPassword = "123456", nnhEmail = "tv3@gmail.com"},
        new nnhMember{nnhMemberId = Guid.NewGuid().ToString(), nnhUserName = "member4", nnhFullName = "Thành viên 4", nnhPassword = "123456", nnhEmail = "tv4@gmail.com"},
        new nnhMember{nnhMemberId = Guid.NewGuid().ToString(), nnhUserName = "member5", nnhFullName = "Thành viên 5", nnhPassword = "123456", nnhEmail = "tv5@gmail.com"},
    };
        public IActionResult nnhGetMembers()
        { 
            ViewBag.nnhMembers = nnhMembers;
            return View();
        }

        //GET ://nnhMember/CreateGetMembers
        public IActionResult CreateGetMembers()
        {
            return View();
        }
        //POST ://nnhMember/ CreateGetMembersSubmit
        [HttpPost] // hành động gọi ứng với method là post
        public IActionResult CreateGetMembers(nnhMember member)
        {
            member.nnhMemberId = Guid.NewGuid().ToString();
            nnhMembers.Add(member);
            return RedirectToAction("nnhGetMembers");
        }
    }
}
