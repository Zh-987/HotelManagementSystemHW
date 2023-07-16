using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
