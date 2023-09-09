using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class RoomsController : Controller
  {
    ApplicationContext db;
    public RoomsController(ApplicationContext context)
    {
        db = context;
    }
    public IActionResult Index()
    {
      return View();
    }
  }
}
