using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var values = bm.getBlogbyID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetBlogListWithCategoryByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetAll()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.cv = categoryValues; 
            return View();
        }

        //Blog ekleme
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidation validationRules = new BlogValidation();
            ValidationResult results = validationRules.Validate(p);

            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Now.ToShortDateString();
                p.BlogImage = "";
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = bm.GetById(id);
            bm.TRemove(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        //Blog düzenleme
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = bm.GetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetAll()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Now.ToShortDateString();
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
