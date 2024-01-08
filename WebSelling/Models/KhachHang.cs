using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaKhachHang { get; set; } = null!;
        public string? Username { get; set; }
        public string? TenKhachHang { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public byte? LoaiKhachHang { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? GhiChu { get; set; }

        public virtual TaiKhoan? UsernameNavigation { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
