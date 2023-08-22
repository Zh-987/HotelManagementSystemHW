using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
