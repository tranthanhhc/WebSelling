using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class GioHang
    {
        public string MaGioHang { get; set; } = null!;
        public string? TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaTien { get; set; }
        public string? GhiChu { get; set; }
    }
}
