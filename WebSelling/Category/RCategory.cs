using WebSelling.Models;

namespace WebSelling.Category
{
    public class RCategory : ICategory
    {
        private readonly WDeviceContext _context;
        public RCategory(WDeviceContext context)
        {
            _context = context;
        }
        public LoaiSanPham Add(LoaiSanPham loaiSp)
        {
            _context.LoaiSanPhams.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;

        }

        public LoaiSanPham Delete(string maloaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSanPham> GetAllLoaiSp()
        {
            return _context.LoaiSanPhams;
        }

        public LoaiSanPham GetLoaiSp(string maloai)
        {
            return _context.LoaiSanPhams.Find(maloai);
        }

        public LoaiSanPham Update(LoaiSanPham loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
