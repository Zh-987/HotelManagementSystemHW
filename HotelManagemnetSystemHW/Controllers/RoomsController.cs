using HotelManagemnetSystemHW.Models;
using HotelManagemnetSystemHW.Storage;

using Microsoft.AspNetCore.Mvc;

using System.Xml.Linq;

namespace HotelManagemnetSystemHW.Controllers
{
    public class RoomsController : Controller
    {

        public IActionResult Index()
        {
            List<Room> rooms = DB.GetHotelRooms();
            return View(rooms);
        }

    }
}
