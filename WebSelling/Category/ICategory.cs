using WebSelling.Models;

namespace WebSelling.Category
{
    public interface ICategory
    {
        LoaiSanPham Add(LoaiSanPham loaiSp);
        LoaiSanPham Update(LoaiSanPham loaiSp);
        LoaiSanPham Delete(String maloai);
        LoaiSanPham GetLoaiSp(String maloai);

        IEnumerable<LoaiSanPham> GetAllLoaiSp();
    }
}
