using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Row
{
    public class ActiveCategoryCountComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var c = new Context())
            {
                ViewBag.number = c.Categories.Where(x => x.CategoryStatus == true).Count();
            }
            return View();
        }
    }
}
