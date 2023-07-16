using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
