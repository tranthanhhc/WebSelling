using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        public string MaLoai { get; set; } = null!;
        public string? Loai { get; set; }

        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
