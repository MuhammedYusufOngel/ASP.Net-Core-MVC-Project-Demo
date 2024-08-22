using BusinessLayer.Concrete;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult categoryChart()
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());
            var values = cm.GetAll();

            List<CategoryClass> list = new List<CategoryClass>();
            foreach (var item in values)
            {
                list.Add(new CategoryClass
                {
                    categoryName = item.CategoryName,
                    categoryCount = item.CategoryCount
                });
            }
            return Json(new { jsonlist = list });
        }
    }
}
