using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
