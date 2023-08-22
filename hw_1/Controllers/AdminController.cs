using Microsoft.AspNetCore.Mvc;

namespace hw_1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult HttpHeaders()
        {
            Dictionary<string, string> httphdrs = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                httphdrs.Add(header.Key, header.Value);
            }
            return View(httphdrs);
        }

        public IActionResult Privacy()
        {
            List<string> messages = new List<string>();
            messages.Add("Everything is safe");
            return View(messages);

        }
    }
}
