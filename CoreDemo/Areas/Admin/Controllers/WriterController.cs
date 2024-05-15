using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }

        //Add Writer
        [HttpPost]
        public IActionResult AddWriter(WriterClass p)
        {
            writers.Add(p);
            var JsonWriter = JsonConvert.SerializeObject(p);
            return Json(JsonWriter);
        }

        //Delete Writer
        public IActionResult DeleteWriter(int id)
        {
            var Writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(Writer);
            return Json(writers);
        }

        //Update Writer
        public IActionResult UpdateWriter(WriterClass p)
        {
            var Writer = writers.FirstOrDefault(x => x.ID == p.ID);
            Writer.Name = p.Name;
            var JsonWriter = JsonConvert.SerializeObject(p); 
            return Json(JsonWriter);
        }

        //Get writer with id
        public IActionResult GetWriterByID(int WriterId)
        {
            var FindWriter = writers.FirstOrDefault(x => x.ID == WriterId);
            var JsonWriters = JsonConvert.SerializeObject(FindWriter);
            return Json(JsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID = 1,
                Name = "Ümid"
            },
            new WriterClass
            {
                ID = 2,
                Name = "Yusuf"
            },
            new WriterClass
            {
                ID = 3,
                Name = "Mete"
            }
        };
    }
}
