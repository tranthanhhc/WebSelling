using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class ThongTinKhachHang
    {
        public string? Username { get; set; }
        public string? TenKhachHang { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public byte? LoaiKhachHang { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? GhiChu { get; set; }
        public int MaKhachHang { get; set; }

        public virtual TaiKhoan? UsernameNavigation { get; set; }
    }
}
