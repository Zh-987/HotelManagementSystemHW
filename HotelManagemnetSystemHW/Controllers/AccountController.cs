using HotelManagemnetSystemHW.Filters;
using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
  public class AccountController : Controller
  {

    List<User> users;

    public AccountController()
    {
            users = new List<User> {
            new User("1","Admin", "admin", "admin123", new DateTime(1990, 01, 01), "Male", "admin@localhost", "87771112223", "Kazakhstan", RoleEnum.admin),
            new User("1","Manager", "manager", "manager123", new DateTime(1999, 09, 09), "Female", "manager@localhost", "87112244433", "Russia", RoleEnum.manager),
            new User("1","User", "user", "user123", new DateTime(2002, 02, 03), "Male", "user@localhost", "87476663344", "France", RoleEnum.user)

        };
    }

    [UserAuthorizationFilter("admin", "admin1234")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    [CookiesResourseFilter()]
    public IActionResult Login()
    {
        //return View();
        return PartialView();
    }

    [LoginActionFilter()]
    [HttpPost]
    public IActionResult Login(string login, string password)
    {

        User? user = users.Where(u => u.Username == login && u.Password == password).FirstOrDefault();

        if (user != null) {
            switch ((int)user.Role)
            {
                case 1:
                    return RedirectToAction("Index", "User");
                case 2:
                    return RedirectToAction("Index", "Manager");
                case 3:
                    return RedirectToAction("Index", "Admin");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            //return View();
            return PartialView();
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        //return RedirectToAction("Index", "Home");
        //return View();
        return PartialView();
    }

    [HttpPost]
    public IActionResult Register(string fullname, string username, string password, DateTime dateOfBirth, string sex, string email, string phone, string country)
    {
        if(fullname != null && username != null && password != null && dateOfBirth > new DateTime(1900, 01, 01) && sex != null && email != null && phone != null && country != null) {
            
            User? user = users.Where(u => u.Username == username).FirstOrDefault();

            if (user != null)
            {
               return View();
            }
            else
            {
                int lastId = users.Count();
                user = new User(new Guid().ToString(), fullname, username, password, dateOfBirth, sex, email, phone, country);
                users.Add(user);
                return RedirectToAction("Login", "Account");
            }
        }
        else
        {
            //return View();
            return PartialView();
        }
    }

        public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home");
    }
    }
}
