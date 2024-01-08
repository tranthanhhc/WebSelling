using System.Security.Policy;
using System.Xml.XPath;

namespace WebSelling.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (DanhMucSanPham product, int quantity)
        {
            CartLine? line = Lines.Where(x => x.Product.MaSanPham == product.MaSanPham).FirstOrDefault();
            if (line == null)
            {
               Lines.Add(new CartLine
               {
                   Product = product,
                   Quantity = quantity
               });

            }
            else
            {
                line.Quantity += quantity;
            }

        }
        public void RemoveLine(DanhMucSanPham product) => Lines.RemoveAll( x=> x.Product.MaSanPham == product.MaSanPham);
        public decimal ComputeTotalValue() => (decimal)Lines.Sum(e => e.Product?.GiaLonNhat *  e.Quantity);
        public void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        
        public DanhMucSanPham Product { get; set; }
        public int Quantity { get; set; }
    }
}
