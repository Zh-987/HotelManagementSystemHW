using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
