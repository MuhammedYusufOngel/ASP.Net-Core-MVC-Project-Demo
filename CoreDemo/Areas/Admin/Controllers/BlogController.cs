using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                //Create sheet
                var sheet = workbook.Worksheets.Add("BlogList");
                //Using cells
                sheet.Cell(1, 1).Value = "Blog ID";
                sheet.Cell(1, 2).Value = "Blog Name";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    sheet.Cell(blogRowCount, 1).Value = item.ID;
                    sheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            //return View();
        }

        List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1, BlogName="C# Program"},
                new BlogModel{ID=2, BlogName="WorldsBk"},
                new BlogModel{ID=3, BlogName="Motogp" }
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                //Create sheet
                var sheet = workbook.Worksheets.Add("BlogList");
                //Using cells
                sheet.Cell(1, 1).Value = "Blog ID";
                sheet.Cell(1, 2).Value = "Blog Name";

                int blogRowCount = 2;
                foreach (var item in GetBlogTitleList())
                {
                    sheet.Cell(blogRowCount, 1).Value = item.ID;
                    sheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        List<BlogModel2> GetBlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2 
                { 
                    ID = x.BlogID, 
                    BlogName = x.BlogTitle 
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
