using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class ChiTietSanPham
    {
        public ChiTietSanPham()
        {
            AnhChiTietSps = new HashSet<AnhChiTietSp>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public string MaChiTietSp { get; set; } = null!;
        public string? MaSanPham { get; set; }
        public string? MaKichThuoc { get; set; }
        public string? MaMauSac { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Video { get; set; }
        public double? DonGia { get; set; }
        public double? GiamGia { get; set; }
        public int? SoLuongTon { get; set; }

        public virtual KichThuoc? MaKichThuocNavigation { get; set; }
        public virtual MauSac? MaMauSacNavigation { get; set; }
        public virtual DanhMucSanPham? MaSanPhamNavigation { get; set; }
        public virtual ICollection<AnhChiTietSp> AnhChiTietSps { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
