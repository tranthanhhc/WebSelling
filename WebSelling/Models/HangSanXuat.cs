using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class HangSanXuat
    {
        public HangSanXuat()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        public string MaHangSanXuat { get; set; } = null!;
        public string? HangSanXuat1 { get; set; }
        public string? MaNuocThuongHieu { get; set; }

        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
