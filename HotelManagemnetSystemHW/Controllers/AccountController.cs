using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Login()
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home");
    }
    }
}
