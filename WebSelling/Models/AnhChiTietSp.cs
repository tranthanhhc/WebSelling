using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class AnhChiTietSp
    {
        public string MaChiTietSp { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public short? ViTri { get; set; }

        public virtual ChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;
    }
}
