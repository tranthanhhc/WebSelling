using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSelling.Models;
using WebSelling.Models.Authentication;

namespace WebSelling.Controllers
{
    public class ProfileController : Controller
    {
        private readonly WDeviceContext _db;

        public ProfileController(WDeviceContext db)
        {
            _db = db;
        }
        public IActionResult Index(string Username)
        {
            var khachHang = _db.KhachHangs.FirstOrDefault(x => x.Username == Username);
            return View("Profile", khachHang);
           
        }
        [Route("suathongtin")]
        [HttpGet]
        public IActionResult Profile(string Username)
        {
            var khachHang = _db.KhachHangs.FirstOrDefault(x => x.Username == Username);
            return View("Profile", khachHang);
        }
        [Route("suathongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _db.Update(khachHang);
                _db.SaveChanges();
                return RedirectToAction("Profile","Profile");
            }
            return View(khachHang);

        }


    }
}
