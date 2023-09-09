using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        ApplicationContext db;
        public UserController(ApplicationContext context)
        {
            db = context;
        }

        [Route("{area}")]
        public IActionResult Index()
        {
            List<Room> rooms = db.room.ToList();
            return View(rooms);
        }
    }
}
