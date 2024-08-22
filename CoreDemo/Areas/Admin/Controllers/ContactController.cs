using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        public IActionResult Index()
        {
            using(var context = new Context())
            {
                var values = cm.GetAll();
                return View(values);
            }
        }

        public IActionResult Detail(int id)
        {
            using (var context = new Context())
            {
                var values = cm.GetById(id);
                ViewBag.subject = values.ContactSubject;
                ViewBag.mail = values.ContactMail;
                ViewBag.name = values.ContactUserName;
                ViewBag.date = values.ContactDate;
                ViewBag.message = values.ContactMessage;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            using (var context = new Context())
            {
                var values = context.Contacts.Where(x => x.ContactId == id).FirstOrDefault();
                cm.TRemove(values);
                return RedirectToAction("Index");
            }
        }
    }
}
