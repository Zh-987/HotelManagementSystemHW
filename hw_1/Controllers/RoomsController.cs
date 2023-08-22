using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
