using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
