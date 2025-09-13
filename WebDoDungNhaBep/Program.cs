using Microsoft.EntityFrameworkCore;
using WebDoDungNhaBep.Models;

namespace WebDoDungNhaBep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Lấy connection string từ appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("Employee");
            builder.Services.AddDbContext<ShopDoDungNhaBep02Context>(x => x.UseSqlServer(connectionString));

            // ✅ Thêm Session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian sống của session
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // ✅ Add MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ✅ Middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // ✅ Kích hoạt Session
            app.UseSession();

            // ✅ Route cho Area trước (Admin)
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // ✅ Route mặc định cho site
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
