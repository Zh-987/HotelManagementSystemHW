using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerController : Controller
    {
        [Route("{area}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
