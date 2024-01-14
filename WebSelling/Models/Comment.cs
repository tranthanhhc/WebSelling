using System;
using System.Collections.Generic;

namespace WebSelling.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string NoiDung { get; set; } = null!;
        public string? Username { get; set; }
        public DateTime DatePosted { get; set; }

        public virtual TaiKhoan? UsernameNavigation { get; set; }
    }
}
