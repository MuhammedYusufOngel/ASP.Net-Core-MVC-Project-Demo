using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;
using Context = DataAccessLayer.Concrete.Context;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.inboxNumber = c.Message2s.Where(x => x.ReceiverID == writerID && x.MessageStatus == false).Count();
            return View();
        }

        [HttpGet]
        public JsonResult GetInBox()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var inBoxs = c.Message2s.Where(x => x.ReceiverID == writerID).ToList();
            for (int i = 0; i < inBoxs.Count; i++)
            {
                var senderWriter = c.Writers.Where(x => x.WriterID == inBoxs[0].SenderID).FirstOrDefault();
                inBoxs[i].SenderWriter = senderWriter;
            }

            string json = JsonSerializer.Serialize(inBoxs, options);

            return Json(json);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = mm.GetById(id);
            mm.TRemove(values);
            return RedirectToAction("InBox");
        }

        public IActionResult MarkAsRead(int id)
        {
            var values = mm.GetById(id);
            values.MessageStatus = true;
            mm.TUpdate(values);
            return RedirectToAction("InBox");
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            UserManager um = new UserManager(new EFUserRepository());
            var users = um.GetAll();

            List<SelectListItem> userValues = (from x in users.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NameSurname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();

            ViewBag.users = userValues;
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(c => c.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(c=>c.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            mm.TAdd(p);
            return RedirectToAction("SendBox");
        }

        public IActionResult MailDetail(int id)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = c.Message2s.Where(x => x.MessageID == id).FirstOrDefault();
            var senderWriter = c.Writers.Where(x => x.WriterID == values.SenderID).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.subject = values.Subject;
            ViewBag.details = values.MessageDetails;
            ViewBag.senderWriter = senderWriter;
            ViewBag.date = values.MessageDate;
            ViewBag.inboxNumber = c.Message2s.Where(x => x.ReceiverID == writerID && x.MessageStatus == false).Count();
            return View();
        }
    }
}
