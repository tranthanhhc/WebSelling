using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class LoaiDt
    {
        public LoaiDt()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        public string MaDt { get; set; } = null!;
        public string? TenLoai { get; set; }

        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
