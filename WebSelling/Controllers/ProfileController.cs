using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSelling.Models;
using WebSelling.Models.Authentication;

namespace WebSelling.Controllers
{
    public class ProfileController : Controller
    {
        WDeviceContext db = new WDeviceContext();

        public IActionResult Index(string Username)
        {
            var khachHang = db.ThongTinKhachHangs.FirstOrDefault(x =>x.Username == Username);
            return View("Profile", khachHang);
           
        }
        [Route("suathongtin")]
        [HttpGet]
        public IActionResult Profile(int maKhachHang)
        {
            var khachHang = db.ThongTinKhachHangs.Find(maKhachHang);
            return View(khachHang);
        }
        [Route("suathongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(ThongTinKhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var existingKhachHang = db.ThongTinKhachHangs.Find(khachHang.MaKhachHang);
                if (existingKhachHang != null)
                {
                    existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                    existingKhachHang.NgaySinh = khachHang.NgaySinh;
                    existingKhachHang.SoDienThoai = khachHang.SoDienThoai;
                    existingKhachHang.DiaChi = khachHang.DiaChi;

                    db.Update(existingKhachHang);
                    db.SaveChanges();

                    var updatedKhachHang = db.ThongTinKhachHangs.Find(khachHang.MaKhachHang);
                    return View("Profile", updatedKhachHang);
                }
            }

            return View(khachHang);
        }
    }
}
