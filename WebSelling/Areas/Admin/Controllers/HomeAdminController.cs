using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSelling.Models;
using WebSelling.Models.Authentication;
using X.PagedList;

namespace WebSelling.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]


    public class HomeAdminController : Controller
    {
        WDeviceContext db = new WDeviceContext();

        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        [Authentication]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.DanhMucSanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);
            PagedList<DanhMucSanPham> lst = new PagedList<DanhMucSanPham>(lstsanpham, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        [Authentication]

        public IActionResult AddNewProduct()
        {
            ViewBag.MaChatLieu = new SelectList(db.ChatLieus.ToList(), "MaChatLieu", "ChatLieu1");
            ViewBag.MaHangSanXuat = new SelectList(db.HangSanXuats.ToList(), "MaHangSanXuat", "HangSanXuat1");
            ViewBag.MaNuocSanXuat = new SelectList(db.QuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.LoaiDts.ToList(), "MaDt", "TenLoai");

            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewProduct(DanhMucSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);

        }

        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult UpdateProduct(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.ChatLieus.ToList(), "MaChatLieu", "ChatLieu1");
            ViewBag.MaHangSanXuat = new SelectList(db.HangSanXuats.ToList(), "MaHangSanXuat", "HangSanXuat1");
            ViewBag.MaNuocSanXuat = new SelectList(db.QuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.LoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = db.DanhMucSanPhams.Find(maSanPham);
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult UpdateProduct(DanhMucSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);

        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult DeleteProduct(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPhams = db.ChiTietSanPhams.Where(x => x.MaSanPham == maSanPham).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPhams = db.AnhSanPhams.Where(x => x.MaSanPham == maSanPham);
            if (anhSanPhams.Any()) db.RemoveRange(anhSanPhams);
            db.Remove(db.DanhMucSanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản Phẩm đã được xóa ";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("chitietsanpham")]
        [Authentication]

        public IActionResult ChiTietSanPham(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSP = db.ChiTietSanPhams.AsNoTracking().OrderBy(x => x.MaChiTietSp);
            PagedList<ChiTietSanPham> lst = new PagedList<ChiTietSanPham>(lstSP, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemMoiChiTiet")]
        [HttpGet]
        public IActionResult AddNewDetail()
        {
            ViewBag.MaSanPham = new SelectList(db.DanhMucSanPhams.ToList(), "MaSanPham","TenSanPham");
            ViewBag.MaKichThuoc = new SelectList(db.KichThuocs.ToList(), "MaKichThuoc","KichThuoc1");
            ViewBag.MaMauSac = new SelectList(db.MauSacs.ToList(), "MaMauSac", "TenMauSac");

            return View();
        }
        [Route("ThemMoiChiTiet")]
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult AddNewDetail(ChiTietSanPham sanPham)
        {
            if(ModelState.IsValid)
            {
                db.ChiTietSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham");

            }
            return View(sanPham);
        }
        [Route("SuaChiTiet")]
        [HttpGet]

        public IActionResult UpdateDetail(string maSanPham)
        {
            ViewBag.MaSanPham = new SelectList(db.DanhMucSanPhams.ToList(), "MaSanPham", "TenSanPham");
            ViewBag.MaKichThuoc = new SelectList(db.KichThuocs.ToList(), "MaKichThuoc", "KichThuoc1");
            ViewBag.MaMauSac = new SelectList(db.MauSacs.ToList(), "MaMauSac", "TenMauSac");
            var sanPham = db.ChiTietSanPhams.Find(maSanPham);
            return View(sanPham);
        }

        [Route("SuaChiTiet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult UpdateDetail(ChiTietSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "HomeAdmin");
            }
            return View(sanPham);

        }
        [Route("XoaChiTiet")]
        [HttpGet]
        public IActionResult DeleteDetail(string maSanPham)
        {
            TempData["Message"] = "";
            var danhMucSanPhams = db.DanhMucSanPhams.Where(x => x.MaSanPham == maSanPham).ToList();
            if (danhMucSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm";
                return RedirectToAction("ChiTietSanPham", "HomeAdmin");
            }
            var anhSanPhams = db.AnhSanPhams.Where(x => x.MaSanPham == maSanPham);
            if (anhSanPhams.Any()) db.RemoveRange(anhSanPhams);
            db.Remove(db.ChiTietSanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản Phẩm đã được xóa ";
            return RedirectToAction("ChiTietSanPham", "HomeAdmin");
        }
        [Route("khachhang")]
        [Authentication]
        public IActionResult KhachHang(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstKH = db.KhachHangs.AsNoTracking().OrderBy(x => x.MaKhachHang);
            PagedList<KhachHang> lst = new PagedList<KhachHang>(lstKH, pageNumber, pageSize);
            return View(lst);
        }

        [Route("SuaKhachHang")]
        [HttpGet]
        public IActionResult UpdateUser(string maKH)
        {
            ViewBag.Username = new SelectList(db.TaiKhoans.ToList(), "Username", "Username");
            var kH = db.KhachHangs.Find(maKH);
            return View(kH);
            
        }
        [Route("SuaKhachHang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult UpdateUser(KhachHang kH)
        {
            if (ModelState.IsValid)
            {
                db.Update(kH);
                db.SaveChanges();
                return RedirectToAction("KhachHang", "HomeAdmin");
            }
            return View(kH);

        }
    }
}
