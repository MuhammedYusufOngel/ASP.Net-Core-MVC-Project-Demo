using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistics4 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = c.Admins.Select(x => x.Name).Take(1).FirstOrDefault();
            ViewBag.adminImage = c.Admins.Select(y => y.ImageURL).Take(1).FirstOrDefault();
            ViewBag.adminDescp = c.Admins.Select(z => z.ShortDescription).Take(1).FirstOrDefault();
            return View();
        }
    }
}
