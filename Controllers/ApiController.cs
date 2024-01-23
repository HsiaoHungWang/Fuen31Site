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
            //return Content("Hello Content");
            //return Content("<h2>Hello Content</h2>", "text/html");
            return Content("<h2>Content, 你好</h2>","text/plain",System.Text.Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
    }
}
