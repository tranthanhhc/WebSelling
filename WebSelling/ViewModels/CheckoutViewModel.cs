using WebSelling.Models;

namespace WebSelling.ViewModels
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        public HoaDonKhachHang HoaDonKH { get; set; }
        public CartLine cartLine { get; set; }
        
    }
}
