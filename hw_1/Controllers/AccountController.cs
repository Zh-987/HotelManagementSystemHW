using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
