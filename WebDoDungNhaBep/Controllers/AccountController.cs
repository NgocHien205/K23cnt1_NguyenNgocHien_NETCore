using Microsoft.AspNetCore.Mvc;
using WebDoDungNhaBep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebDoDungNhaBep.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopDoDungNhaBep02Context _context;

        public AccountController(ShopDoDungNhaBep02Context context)
        {
            _context = context;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin.";
                return View();
            }

            var user = await _context.Admins
                .FirstOrDefaultAsync(a => a.TenDangNhap == username && a.MatKhau == password);

            if (user == null)
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu.";
                return View();
            }

            // Lưu thông tin vào session
            HttpContext.Session.SetInt32("MaAdmin", user.MaAdmin);
            HttpContext.Session.SetString("HoTen", user.HoTen);
            HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
            HttpContext.Session.SetInt32("VaiTro", user.VaiTro);

            // Điều hướng theo vai trò
            if (user.VaiTro == 2) // Admin
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            else // Khách hàng
                return RedirectToAction("Index", "Home", new { area = "" });
        }

        // GET: Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Register (chỉ cho khách hàng)
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register (chỉ cho khách hàng)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string hoTen, string diaChi, string soDienThoai, string tenDangNhap, string email, string matKhau)
        {
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(tenDangNhap)
                || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin bắt buộc.";
                return View();
            }

            // Kiểm tra trùng tên đăng nhập hoặc email
            var exists = await _context.Admins.AnyAsync(a => a.TenDangNhap == tenDangNhap || a.Email == email);
            if (exists)
            {
                ViewBag.Error = "Tên đăng nhập hoặc email đã tồn tại.";
                return View();
            }

            var user = new Admin
            {
                HoTen = hoTen,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai,
                TenDangNhap = tenDangNhap,
                Email = email,
                MatKhau = matKhau,
                VaiTro = 1, // 1 = Khách hàng
                TrangThai = "Hoạt động",
                NgayTao = DateTime.Now
            };

            _context.Admins.Add(user);
            await _context.SaveChangesAsync();

            // Tự động đăng nhập sau khi đăng ký
            HttpContext.Session.SetInt32("MaAdmin", user.MaAdmin);
            HttpContext.Session.SetString("HoTen", user.HoTen);
            HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
            HttpContext.Session.SetInt32("VaiTro", user.VaiTro);

            return RedirectToAction("Index", "Home", new { area = "" });

            
        
        }
      
    }
}
