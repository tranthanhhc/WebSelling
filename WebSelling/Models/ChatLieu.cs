using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class ChatLieu
    {
        public ChatLieu()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        public string MaChatLieu { get; set; } = null!;
        public string? ChatLieu1 { get; set; }

        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
