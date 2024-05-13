using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminNavbarResult()
        {
            return PartialView();
        }
    }
}
