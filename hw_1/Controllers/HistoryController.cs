using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
