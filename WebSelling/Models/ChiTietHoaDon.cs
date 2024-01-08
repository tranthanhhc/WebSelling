using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class ChiTietHoaDon
    {
        public string MaHoaDon { get; set; } = null!;
        public string MaChiTietSp { get; set; } = null!;
        public int? SoLuongBan { get; set; }
        public decimal? DonGiaBan { get; set; }
        public double? GiamGia { get; set; }
        public string? GhiChu { get; set; }

        public virtual ChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;
        public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
    }
}
