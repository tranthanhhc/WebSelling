using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class QuocGium
    {
        public QuocGium()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        public string MaNuoc { get; set; } = null!;
        public string? TenNuoc { get; set; }

        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
