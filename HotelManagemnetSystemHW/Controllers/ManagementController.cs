using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class ManagementController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
