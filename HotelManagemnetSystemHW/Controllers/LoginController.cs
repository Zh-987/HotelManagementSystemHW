using HotelManagemnetSystemHW.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagemnetSystemHW.Controllers {
    public class LoginController : Controller {
        private static List<User> users = new List<User>
          {
            new User { Username = "user", Password = "user123", RoleId = (int)UserRole.User },
            new User { Username = "manager", Password = "manager123", RoleId = (int)UserRole.Manager },
            new User { Username = "admin", Password = "admin123", RoleId = (int)UserRole.Admin }
        };

        public ActionResult Index() {
            return View();
        }

        public ActionResult LoginPartial() {
            return PartialView("_LoginPartial");
        }

        [HttpPost]
        public ActionResult Login(string username, string password, bool rememberMe) {
            User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null) {
                switch (user.RoleId) {
                    case (int)UserRole.User:
                        return RedirectToAction("UserDashboard", "User");

                    case (int)UserRole.Manager:
                        return RedirectToAction("ManagerDashboard", "Manager");

                    case (int)UserRole.Admin:
                        return RedirectToAction("AdminDashboard", "Admin");
                }
            }

            return View("Index");
        }
        public ActionResult Register() {
            ViewBag.Roles = new SelectList(Enum.GetValues(typeof(UserRole)));

            return View();
        }

        [HttpPost]
        public ActionResult Register(User newUser) {
            users.Add(newUser);
            return RedirectToAction("Index");
        }
    }
}
