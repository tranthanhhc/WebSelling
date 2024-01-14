using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebSelling.Infrastructure;
using WebSelling.Models;
using WebSelling.Models.Authentication;
using WebSelling.ViewModels;

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
        [Authentication]
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
        [Authentication]
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
            var viewModel = new CheckoutViewModel
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart"),
                HoaDonKH = new HoaDonKhachHang()
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult AddBill(CheckoutViewModel viewModel)
        {
            
            var hoaDon = viewModel.HoaDonKH;
            var cart = HttpContext.Session.GetJson<Cart>("cart");

            hoaDon.TenHang = cart.Lines[0].Product.TenSanPham;
            hoaDon.SoLuong = cart.Lines[0].Quantity;
            hoaDon.TongTien = cart.ComputeTotalValue();
            hoaDon.NgayTao = DateTime.Now;
            db.HoaDonKhachHangs.Add(hoaDon);
            db.SaveChanges();
            TempData["OrderSuccessMessage"] = "Đặt hàng thành công!";

            return RedirectToAction("Checkout");        
        }
    }
}
