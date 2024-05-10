using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.yourBlogs = c.Blogs.Where(x => x.WriterID == 1).Count().ToString();
            ViewBag.categories = c.Categories.Count().ToString();
            return View();
        }
    }
}
