using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();

            ViewBag.v1 = c.Blogs.Count().ToString();

            var username = User.Identity.Name;
            ViewBag.data = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.yourBlogs = c.Blogs.Where(x => x.WriterID == writerid).Count().ToString();
            ViewBag.categories = c.Categories.Count().ToString();
            return View();
        }
    }
}
