using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DefaultController : Controller
    {
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
