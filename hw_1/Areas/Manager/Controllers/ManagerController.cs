using Microsoft.AspNetCore.Mvc;

namespace hw_1.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
