using Microsoft.AspNetCore.Mvc;
using hw_1.Models;

namespace hw_1.Controllers
{
    public class AccountController : Controller
    {

        List<User> users;
        public AccountController()
        {
            users = new List<User> {
            new User(1,"Admin", "admin", "admin123", new DateTime(1990, 01, 01), "Male", "admin@localhost", "87771112223", "Kazakhstan", RoleEnum.admin),
            new User(1,"Manager", "manager", "manager123", new DateTime(1999, 09, 09), "Female", "manager@localhost", "87112244433", "Russia", RoleEnum.manager),
            new User(1,"User", "user", "user123", new DateTime(2002, 02, 03), "Male", "user@localhost", "87476663344", "France", RoleEnum.user)

        };
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            User? user = users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            
            if (user != null)
            {
                switch ((int)user.Role)
                {
                    case 1:
                        return RedirectToAction("Index", "User", new {id = user.Username, area = "User" });
                    case 2:
                        return RedirectToAction("Index", "Manager", new { id = user.Username, area= "Manager" });
                    case 3:
                        return RedirectToAction("Index", "Admin", new { id = user.Username, area = "Admin" });
                    default:
                        return RedirectToAction("Index", "Home", new { id = user.Username });
                }
            }
            else
            {
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }

}
