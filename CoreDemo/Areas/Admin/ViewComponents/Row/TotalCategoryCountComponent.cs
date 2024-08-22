using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Row
{
    public class TotalCategoryCountComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var c = new Context())
            {
                ViewBag.number = c.Categories.Count();
            }
            return View();
        }
    }
}
