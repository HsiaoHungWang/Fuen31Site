using Fuen31Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fuen31Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _dbContext;
        public ApiController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000);
            //return Content("Hello Content");
            //return Content("<h2>Hello Content</h2>", "text/html");
            return Content("Content, 你好","text/plain",System.Text.Encoding.UTF8);
        }

       
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Avatar(int id=1) {
            Member? member = _dbContext.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                return File(img, "image/jpeg");
            }

            return NotFound();
        }
    }
}
