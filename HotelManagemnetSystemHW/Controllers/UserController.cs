using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class UserController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
