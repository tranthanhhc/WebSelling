using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class MauSac
    {
        public MauSac()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        public string MaMauSac { get; set; } = null!;
        public string? TenMauSac { get; set; }

        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
