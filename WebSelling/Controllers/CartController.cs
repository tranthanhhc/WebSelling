using Microsoft.AspNetCore.Mvc;
using WebSelling.Infrastructure;
using WebSelling.Models;

namespace WebSelling.Controllers
{
    public class CartController : Controller
    {
        WDeviceContext db = new WDeviceContext();
        public Cart? Cart { get; set; }      
        public IActionResult Index()
        {

            return View("Cart",HttpContext.Session.GetJson<Cart>("cart"));
        }
        public IActionResult AddToCart(string productId)
        {
            DanhMucSanPham? product = db.DanhMucSanPhams.FirstOrDefault( x =>x.MaSanPham == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart",Cart);
        }
        public IActionResult AddFromProduct(string productId)
        {
            DanhMucSanPham? product = db.DanhMucSanPhams.FirstOrDefault(x => x.MaSanPham == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);

                TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng thành công!";
            }
            return RedirectToAction("ProductDetail", "Home", new { maSp = productId });
        }
        public IActionResult MinusToCart(string productId)
        {
            DanhMucSanPham? product = db.DanhMucSanPhams.FirstOrDefault(x => x.MaSanPham == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult RemoveLineCart(string productId)
        {
            DanhMucSanPham? product = db.DanhMucSanPhams.FirstOrDefault(x => x.MaSanPham == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult Checkout()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart");
            return View("Checkout", Cart);
        }
    }
}
