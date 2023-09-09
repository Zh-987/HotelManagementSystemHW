using HotelManagemnetSystemHW.Areas.User.Models;
using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagemnetSystemHW.Controllers
{
  public class RoomController : Controller
  {
    ApplicationContext db;
    public RoomController(ApplicationContext context)
    {
        db = context;
    }
    public IActionResult Index()
    {
        List<Room> rooms = db.room.ToList();
        return View(rooms);
    }

    [HttpGet]
    public IActionResult CreateRoom()
    {
        return View();
    }

        [HttpPost]
    public async Task<IActionResult> CreateRoomAsync(string name, string description, int personCount, int square, double cost, int hotelId)
    {

        if (name != null && description != null && personCount > 0 && square > 0 && cost > 0 && hotelId > 0)
        {

            Room? room = db.room.FirstOrDefault(r => r.Name == name);

            if (room != null)
            {
                return View();
            }
            else
            {

                Hotel? hotel = db.hotels.FirstOrDefault(h => h.Id == hotelId);

                Room newRoom = new Room
                {
                    Name = name,
                    Description = description,
                    PersonCount = personCount,
                    Square = square,
                    Cost = cost,
                    HotelId = hotelId,
                    Hotel = hotel,
                };

                db.room.Add(newRoom);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Room");
            }
        }
        else
        {
            return View();
        }
    }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Room room = new Room { Id = id.Value };
                db.Entry(room).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Room? room = await db.room.FirstOrDefaultAsync(p => p.Id == id);
                if (room != null) return View(room);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Room room)
        {
            db.room.Update(room);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
