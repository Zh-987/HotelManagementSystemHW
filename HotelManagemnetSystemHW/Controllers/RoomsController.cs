using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class RoomsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
