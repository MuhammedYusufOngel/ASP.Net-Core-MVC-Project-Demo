﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = mm.GetById(id);
            value.SenderWriter = c.Writers.Where(x => x.WriterID == value.SenderID).FirstOrDefault();
            value.ReceiverWriter = c.Writers.Where(x => x.WriterID == value.ReceiverID).FirstOrDefault();
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
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
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 4;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("Inbox");
        }

    }
}
