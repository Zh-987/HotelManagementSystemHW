using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace HotelManagemnetSystemHW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        ApplicationContext db;
        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        [Route("{area}")]
        public IActionResult Index()
        {
            List<HotelManagemnetSystemHW.Models.User> users = db.users.ToList();
            return View(users);
        }

        public IActionResult HttpHeaders()
        {
            Dictionary<string, string> htmlHeaders = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                htmlHeaders.Add(header.Key, header.Value);
            }
            return View(htmlHeaders);
        }
    }
}
