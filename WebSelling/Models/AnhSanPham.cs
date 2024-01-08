using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class AnhSanPham
    {
        public string MaSanPham { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public short? ViTri { get; set; }

        public virtual DanhMucSanPham MaSanPhamNavigation { get; set; } = null!;
    }
}
