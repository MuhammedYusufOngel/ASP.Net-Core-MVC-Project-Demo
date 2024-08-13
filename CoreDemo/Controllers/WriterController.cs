using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
        WriterManager wm = new WriterManager(new EFWriterRepository());
        UserManager um = new UserManager(new EFUserRepository());

        private readonly UserManager<AppUser> userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
		public IActionResult Index()
		{
            var usermail = User.Identity?.Name;
            ViewBag.v = usermail;

            Context c = new Context();
            var name = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.name = name;

			return View();
		}
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditResult()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditResult(UserUpdateViewModel model)
        {
            //WriterValidation w1 = new WriterValidation();
            //ValidationResult results = w1.Validate(p);
            //if(results.IsValid)
            //{
            //    p.WriterImage = "https://img.freepik.com/free-vector/isolated-young-handsome-man-different-poses-white-background-illustration_632498-859.jpg?size=338&ext=jpg&ga=GA1.1.34264412.1715126400&semt=ais";
            //    wm.TUpdate(p);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach(var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            var values = await userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.UserName = model.username;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            values.PasswordHash = userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await userManager.UpdateAsync(values);

            if (result.Succeeded)
                return RedirectToAction("Index", "Dashboard");

            else
                return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if(p.WriterImage != null)
            {
                //Buraya bakacağım
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = p.WriterStatus;
            w.WriterAbout = p.WriterAbout;

            wm.TAdd(w);
            return RedirectToAction("Index","Dashboard");
        }

    }
}
