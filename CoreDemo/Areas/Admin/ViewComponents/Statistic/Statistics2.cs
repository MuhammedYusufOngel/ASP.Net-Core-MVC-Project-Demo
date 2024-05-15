using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistics2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.recentBlogTitle = c.Blogs.OrderByDescending(y => y.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.recentBlogDate = c.Blogs.OrderByDescending(y => y.BlogID).Select(x => x.BlogCreateDate).Take(1).FirstOrDefault();
            ViewBag.totalComments = c.Comments.Count();
            return View();
        }
    }
}
