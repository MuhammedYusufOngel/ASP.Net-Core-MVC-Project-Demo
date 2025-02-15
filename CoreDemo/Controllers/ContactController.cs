﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
	public class ContactController : Controller
	{
        ContactManager cm = new ContactManager(new EFContactRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
        }
        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = true;

            cm.AddContact(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
