using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public string MaDonHang { get; set; } = null!;
        public string? MaKhachHang { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public decimal? TongTien { get; set; }
        public string? DiaChiGiaoHang { get; set; }
        public string? GhiChu { get; set; }

        public virtual KhachHang? MaKhachHangNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
