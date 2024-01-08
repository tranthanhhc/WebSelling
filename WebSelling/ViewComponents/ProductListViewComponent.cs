using WebSelling.Models;
using Microsoft.AspNetCore.Mvc;
using WebSelling.Category;

namespace WebSelling.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly ICategory _loaiSp;
        public ProductListViewComponent(ICategory loaiSpcategory)
        {
            _loaiSp = loaiSpcategory;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);

        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var cateList = await this._db.Categories.ToListAsync();
        //    return View(cateList);
        //}
    }
}
