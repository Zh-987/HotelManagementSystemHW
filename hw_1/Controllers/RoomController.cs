using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
