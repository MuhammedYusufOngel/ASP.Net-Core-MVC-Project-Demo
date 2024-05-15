using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult categoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName = "Teknoloji",
                categoryCount = 10
            });
            list.Add(new CategoryClass
            {
                categoryName = "Yazılım",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "MotoGP",
                categoryCount = 5
            });

            return Json(new { jsonlist = list });
        }
    }
}
