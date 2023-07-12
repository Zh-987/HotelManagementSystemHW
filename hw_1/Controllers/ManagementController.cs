using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
