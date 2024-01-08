using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSelling.Models;
using WebSelling.ViewModels;
using X.PagedList;

namespace WebSelling.Controllers
{
    public class HomeController : Controller
    {
        WDeviceContext db = new WDeviceContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.DanhMucSanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);
            PagedList<DanhMucSanPham> lst = new PagedList<DanhMucSanPham>(lstsanpham, pageNumber, pageSize);        
            return View(lst);
        }

        public IActionResult ProductCategory(String maLoai, int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanpham = db.DanhMucSanPhams.AsNoTracking().Where(x=>x.MaLoai==maLoai).OrderBy(x=>x.TenSanPham);
            PagedList<DanhMucSanPham> lst = new PagedList<DanhMucSanPham>(lstSanpham, pageNumber, pageSize);
            ViewBag.MaLoai = maLoai;

            return View(lst);
        }

        public IActionResult Detail (String maSp )
        {
            var sanPham  = db.DanhMucSanPhams.SingleOrDefault(x=>x.MaSanPham == maSp);
            var anhSanPham = db.AnhSanPhams.Where(x => x.MaSanPham == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }

        public IActionResult ProductDetail(String maSp)
        {
            var sanPham = db.DanhMucSanPhams.SingleOrDefault(x => x.MaSanPham == maSp);
            var anhSanPham = db.AnhSanPhams.Where(x => x.MaSanPham == maSp).ToList();
            var productDetailViewModel = new ProductDetailViewModel
            {
                danhMucSp = sanPham,
                anhSps = anhSanPham
            };
            return View(productDetailViewModel);
        }

        public IActionResult AllProducts(int? page, string strSearch, string sortOrder)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.DanhMucSanPhams.AsNoTracking();

            // Sắp xếp tăng dần/giảm dần
            switch (sortOrder)
            {
                case "GiaTang":
                    lstsanpham = lstsanpham.OrderBy(x => x.GiaLonNhat);
                    break;
                case "GiaGiam":
                    lstsanpham = lstsanpham.OrderByDescending(x => x.GiaLonNhat);
                    break;
                default:
                    lstsanpham = lstsanpham.OrderBy(x => x.TenSanPham);
                    break;
            }

            PagedList<DanhMucSanPham> lst = new PagedList<DanhMucSanPham>(lstsanpham, pageNumber, pageSize);

            if (!string.IsNullOrEmpty(strSearch))
            {
                List<DanhMucSanPham> danhMucSanPhams = lst.Where(x => x.TenSanPham.IndexOf(strSearch, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                PagedList<DanhMucSanPham> pagedDanhMucSanPhams = new PagedList<DanhMucSanPham>(danhMucSanPhams, pageNumber, pageSize);
                lst = pagedDanhMucSanPhams;
            }

            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }   
    }
}