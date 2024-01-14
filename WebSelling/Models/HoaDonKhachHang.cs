using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class HoaDonKhachHang
    {
        public int MaHoaDon { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? TenHang { get; set; }
        public int? SoLuong { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
