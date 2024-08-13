using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.VariantTypes;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserSignInViewModel model = new UserSignInViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(p.username, p.password, true, true);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Dashboard");
                else
                    return RedirectToAction("Index", "Login");
            }
            
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}



//HttpContext.Session.SetString("username", p.WriterMail);