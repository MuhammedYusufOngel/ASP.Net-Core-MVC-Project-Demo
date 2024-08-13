using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.name
                };

                var result = await roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                id = values.Id,
                name = values.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values = roleManager.Roles.Where(x => x.Id == model.id).FirstOrDefault();

            values.Name = model.name;
            var result = await roleManager.UpdateAsync(values);

            if (result.Succeeded)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            var result = await roleManager.DeleteAsync(values);

            if (result.Succeeded)
                return RedirectToAction("Index");

            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            
            foreach(var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleID = item.Id;
                m.Name = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                model.Add(m);
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = userManager.Users.FirstOrDefault(x => x.Id == userid);
            
            foreach(var item in model)
            {
                if (item.Exists)
                    await userManager.AddToRoleAsync(user, item.Name);

                else
                    await userManager.RemoveFromRoleAsync(user, item.Name);
            }
            
            return RedirectToAction("UserRoleList");
        }
    }
}
