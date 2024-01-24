using Fuen31Site.Models;
using Fuen31Site.Models.DTO;
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
            System.Threading.Thread.Sleep(10000);
            //return Content("Hello Content");
            //return Content("<h2>Hello Content</h2>", "text/html");
            return Content("Content, 你好","text/plain",System.Text.Encoding.UTF8);
        }

       
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Districts(string city) {
            var districts = _dbContext.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
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

        // public IActionResult Register(string name, int age = 26)
        public IActionResult Register(UserDTO _user)
        {
            if (string.IsNullOrEmpty(_user.Name))
            {
                _user.Name = "Guest";
            }
            return Content($"Hello {_user.Name}, {_user.Age}歲了,電子郵件是{_user.Email}");
        }
    }
}
