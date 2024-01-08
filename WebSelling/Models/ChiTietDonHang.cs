using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class ChiTietDonHang
    {
        public string MaDonHang { get; set; } = null!;
        public string MaSanPham { get; set; } = null!;
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public string? GhiChu { get; set; }

        public virtual DonHang MaDonHangNavigation { get; set; } = null!;
        public virtual DanhMucSanPham MaSanPhamNavigation { get; set; } = null!;
    }
}
