using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? LoaiUser { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
