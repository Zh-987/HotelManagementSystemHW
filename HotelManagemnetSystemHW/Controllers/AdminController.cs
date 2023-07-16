using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
