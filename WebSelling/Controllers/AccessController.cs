using Microsoft.AspNetCore.Mvc;
using WebSelling.Models;

namespace WebSelling.Controllers
{
    public class AccessController : Controller
    {
        WDeviceContext db = new WDeviceContext();
        [HttpGet]

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TaiKhoan user ) { 
            if(HttpContext.Session.GetString("UserName") == null)
            {
                var u =db.TaiKhoans.Where( x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    if (u.LoaiUser.HasValue)
                    {
                        HttpContext.Session.SetInt32("Loai_user", u.LoaiUser.Value);
                    }
                    if (u.LoaiUser == 0 )
                    {
                        return RedirectToAction("Index","admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(TaiKhoan user)
        {
            // Kiểm tra sự tồn tại của người dùng trong cơ sở dữ liệu và thêm mới nếu không tồn tại
            var existingUser = db.TaiKhoans.FirstOrDefault(x => x.Username.Equals(user.Username));
            if (existingUser == null)
            {
                db.TaiKhoans.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại");
            }

            return View(user);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

    }
}
