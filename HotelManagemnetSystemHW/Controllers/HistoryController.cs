using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class HistoryController : Controller
  {
    ApplicationContext db;
    public HistoryController(ApplicationContext context)
    {
        db = context;
    }
    public IActionResult Index()
    {
      return View();
    }
  }
}
