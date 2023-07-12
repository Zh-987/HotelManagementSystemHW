using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class AdminController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult HttpHeaders()
    {
        Dictionary<string, string> htmlHeaders = new Dictionary<string, string>();
        foreach (var header in Request.Headers)
        {
           htmlHeaders.Add(header.Key, header.Value);
        }
        return View(htmlHeaders);
    }
    }
}
