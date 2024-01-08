using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class KichThuoc
    {
        public KichThuoc()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        public string MaKichThuoc { get; set; } = null!;
        public string? KichThuoc1 { get; set; }

        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
