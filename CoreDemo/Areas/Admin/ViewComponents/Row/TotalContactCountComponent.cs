using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Row
{
    public class TotalContactCountComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var c = new Context())
            {
                ViewBag.number = c.Contacts.Count();
            }
            return View();
        }
    }
}
