using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EFWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidation validationRules = new WriterValidation();
			ValidationResult results = validationRules.Validate(p);

			if(results.IsValid)
			{
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
				p.WriterImage = "deneme";
				wm.AddWriter(p);
                return RedirectToAction("Index", "Blog");
            }
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
        }
	}
}
