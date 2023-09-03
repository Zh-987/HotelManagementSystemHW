using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        [Route("{area}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
