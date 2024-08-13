using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNameImageComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;

            using (var c = new Context())
            {
                ViewBag.name = c.Users.Where(x => x.UserName == username).Select(x => x.NameSurname).FirstOrDefault();
                var mail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
                ViewBag.image = c.Writers.Where(x => x.WriterMail == mail).Select(x => x.WriterImage).FirstOrDefault();
            }

            return View();
        }
    }
}
