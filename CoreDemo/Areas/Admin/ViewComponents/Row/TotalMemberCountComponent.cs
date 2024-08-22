using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDemo.Areas.Admin.ViewComponents.Row
{
    public class TotalMemberCountComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var c = new Context())
            {
                ViewBag.number = c.Writers.Count();
            }
            return View();
        }
    }
}
