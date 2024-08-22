using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistics4 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();

            ViewBag.adminName = c.Admins.Select(x => x.Name).Take(1).FirstOrDefault();
            ViewBag.adminImage = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterImage).FirstOrDefault();
            ViewBag.adminDescp = c.Admins.Select(z => z.ShortDescription).Take(1).FirstOrDefault();
            ViewBag.phonenumber = c.Users.Where(x => x.UserName == username).Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.mail = usermail;
            return View();
        }
    }
}
