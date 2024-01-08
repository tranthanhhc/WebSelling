using WebSelling.Models;

using Microsoft.AspNetCore.Mvc;
using WebSelling.Infrastructure;

namespace WebSelling.ViewComponents
{
    public class CartWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("cart"));
        }


    }
}
