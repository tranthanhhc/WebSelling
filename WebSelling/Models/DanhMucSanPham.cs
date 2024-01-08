using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class DanhMucSanPham
    {
        public DanhMucSanPham()
        {
            AnhSanPhams = new HashSet<AnhSanPham>();
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        public string MaSanPham { get; set; } = null!;
        public string? TenSanPham { get; set; }
        public string? MaChatLieu { get; set; }
        public string? Model { get; set; }
        public double? CanNang { get; set; }
        public string? MaHangSanXuat { get; set; }
        public string? MaNuocSanXuat { get; set; }
        public string? MaDacTinh { get; set; }
        public int? ThoiGianBaoHanh { get; set; }
        public string? GioiThieuSanPham { get; set; }
        public double? ChietKhau { get; set; }
        public string? MaLoai { get; set; }
        public string? MaDt { get; set; }
        public string? AnhSanPham { get; set; }
        public decimal? GiaNhoNhat { get; set; }
        public decimal? GiaLonNhat { get; set; }

        public virtual ChatLieu? MaChatLieuNavigation { get; set; }
        public virtual LoaiDt? MaDtNavigation { get; set; }
        public virtual HangSanXuat? MaHangSanXuatNavigation { get; set; }
        public virtual LoaiSanPham? MaLoaiNavigation { get; set; }
        public virtual QuocGium? MaNuocSanXuatNavigation { get; set; }
        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
