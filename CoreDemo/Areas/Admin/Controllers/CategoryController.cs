using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Controllers;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Category = EntityLayer.Concrete.Category;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            //ToPagedList(page number, page size?)
            var values = cm.GetAll().ToPagedList(page, 3);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidation validationRules = new CategoryValidation();
            ValidationResult results = validationRules.Validate(p);

            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //Blog silme
        public IActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            cm.TRemove(categoryValue);
            return RedirectToAction("Index","Category");
        }
    }
}
