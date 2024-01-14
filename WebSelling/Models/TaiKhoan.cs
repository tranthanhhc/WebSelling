using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            Comments = new HashSet<Comment>();
            GioHangs = new HashSet<GioHang>();
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
            ThongTinKhachHangs = new HashSet<ThongTinKhachHang>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? LoaiUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<ThongTinKhachHang> ThongTinKhachHangs { get; set; }
    }
}
