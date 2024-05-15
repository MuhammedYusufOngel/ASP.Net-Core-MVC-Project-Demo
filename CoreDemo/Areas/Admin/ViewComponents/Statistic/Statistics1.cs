using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.AdditionalCharacteristics;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistics1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlogs = bm.GetAll().Count();
            ViewBag.totalMessages = c.Contacts.Count();
            ViewBag.totalComments = c.Comments.Count();


            string api = "053d3fb7637d4ee7ccad0d118d288d09";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=sakarya&mode=xml&appid=" + api;
            XDocument document = XDocument.Load(connection);
            string ApiKelvin = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            int ApiCelcius = 0;

            for(int i= 0; i < ApiKelvin.Length; i++)
            {
                if (Char.IsDigit(ApiKelvin[i]))
                {
                    int pow = Convert.ToInt32(Math.Pow(10, 2 - i));
                    int number = ApiKelvin[i] - 48;
                    ApiCelcius += (pow * number);
                }

                else
                {
                    break;
                }
            }

            
            //int ApiCelcius = Convert.ToInt32(ApiKelvin) - 273;

            ViewBag.api = (ApiCelcius - 273);

            return View();
        }
    }
}
