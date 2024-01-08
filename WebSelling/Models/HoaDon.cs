using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public string MaHoaDon { get; set; } = null!;
        public DateTime? NgayHoaDon { get; set; }
        public string? MaKhachHang { get; set; }
        public string? MaNhanVien { get; set; }
        public decimal? TongTien { get; set; }
        public double? GiamGia { get; set; }
        public byte? PhuongThucThanhToan { get; set; }
        public string? MaSoThue { get; set; }
        public string? ThongTinThue { get; set; }
        public string? GhiChu { get; set; }

        public virtual KhachHang? MaKhachHangNavigation { get; set; }
        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
