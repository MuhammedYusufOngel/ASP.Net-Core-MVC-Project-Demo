using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
