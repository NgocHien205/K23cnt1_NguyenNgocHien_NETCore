using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nnhNetCoreMVCLAB5.Models;
using System.Security.Principal;

namespace nnhNetCoreMVCLAB5.Controllers
{
    public class nnhAccountController : Controller
    {
        // Danh sách tài khoản tĩnh, dùng tạm thay cho database
        private static List<nnhAccount> accounts = new List<nnhAccount>()
        {
            new nnhAccount
            {
                NnhId = 1,
                NnhFullName = "Nguyễn Ngọc Hiến",
                NnhEmail = "ngochien@gmail.com",
                NnhPhone = "0336076551",
                NnhAddress = "Thái Bình",
                NnhAvatar = "avatar1.png",
                NnhBirthday = new DateTime(2005, 06, 13),
                NnhGender = "Nam",
                NnhPassword = "12345678",
                NnhFacebook = "https://www.facebook.com/nguyen.ngoc.hien.967738"
            },
            new nnhAccount
            {
                NnhId = 2,
                NnhFullName = "Trần Thị B",
                NnhEmail = "thib@example.com",
                NnhPhone = "0981234567",
                NnhAddress = "Đà Nẵng",
                NnhAvatar = "avatar2.png",
                NnhBirthday = new DateTime(1995, 10, 10),
                NnhGender = "Nữ",
                NnhPassword = "password2",
                NnhFacebook = "https://facebook.com/thib"
            },
            new nnhAccount
            {
                NnhId = 3,
                NnhFullName = "Lê Văn C",
                NnhEmail = "vanc@example.com",
                NnhPhone = "0977654321",
                NnhAddress = "TP.HCM",
                NnhAvatar = "avatar3.png",
                NnhBirthday = new DateTime(1988, 3, 15),
                NnhGender = "Nam",
                NnhPassword = "password3",
                NnhFacebook = "https://facebook.com/vanc"
            }
        };

        // GET: NnhAccountController
        public ActionResult nnhIndex()
        {
            return View(accounts);
        }

        // GET: Hiển thị form tạo mới tài khoản
        public ActionResult nnhCreate()
        {
            nnhAccount models = new nnhAccount(); // Tạo một model rỗng
            return View(models);
        }

        // POST: Xử lý dữ liệu khi submit form tạo mới tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult nnhCreate(nnhAccount models)
        {
            try
            {
                // Sinh mã ID tự động nếu chưa có
                if (models.NnhId == 0)
                {
                    if (accounts.Count > 0)
                    {
                        models.NnhId = accounts.Max(e => e.NnhId) + 1;
                    }
                    else
                    {
                        models.NnhId = 1;
                    }
                }

                // Thêm model vào danh sách
                accounts.Add(models);

                // Chuyển về trang danh sách sau khi thêm thành công
                return RedirectToAction(nameof(nnhIndex));
            }
            catch
            {
                // Nếu có lỗi, hiển thị lại form với dữ liệu đã nhập
                return View(models);
            }
        }


        // GET: Edit
        public ActionResult nnhEdit(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NnhId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult nnhEdit(int id, nnhAccount updatedAccount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.NnhId == id);
                if (account == null)
                    return NotFound();

                // Cập nhật thông tin
                account.NnhFullName = updatedAccount.NnhFullName;
                account.NnhEmail = updatedAccount.NnhEmail;
                account.NnhPhone = updatedAccount.NnhPhone;
                account.NnhAddress = updatedAccount.NnhAddress;
                account.NnhAvatar = updatedAccount.NnhAvatar;
                account.NnhBirthday = updatedAccount.NnhBirthday;
                account.NnhGender = updatedAccount.NnhGender;
                account.NnhPassword = updatedAccount.NnhPassword;
                account.NnhFacebook = updatedAccount.NnhFacebook;

                return RedirectToAction(nameof(nnhIndex));
            }
            catch
            {
                return View(updatedAccount);
            }
        }


        public ActionResult nnhDetails(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NnhId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }


        // GET: Delete
        public ActionResult nnhDelete(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NnhId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Delete
        [HttpPost, ActionName("nnhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NnhId == id);
            if (account != null)
            {
                accounts.Remove(account);
            }
            return RedirectToAction(nameof(nnhIndex));
        }
    
    }
}
