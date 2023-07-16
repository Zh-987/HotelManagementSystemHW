using HotelManagemnetSystemHW.Storage;

using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnetSystemHW.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index(string roomNumber)
        {
            ViewData["RoomNumber"] = roomNumber;
            return View(DB.GetRoom(int.Parse(roomNumber)));
        }
    }
}
