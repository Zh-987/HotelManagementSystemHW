using HotelManagemnetSystemHW.Areas.User.Models;
using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagemnetSystemHW.Controllers
{
  public class RoomController : Controller
  {
    ApplicationContext db;
    public RoomController(ApplicationContext context)
    {
        db = context;
    }
    //public IActionResult Index()
    //{
    //    List<Room> rooms = db.room.ToList();
    //    return View(rooms);
    //}

       
    public ActionResult Index(string? name, double? cost, int? square, int? personCount, RoomsSortState sortOrder = RoomsSortState.IdAsc, int page = 1)
    {
        int pageSize = 3;   // количество элементов на странице

        IQueryable<Room>? rooms = db.room;

        if (personCount.HasValue)
        {
            rooms = rooms.Where(r => r.PersonCount == personCount);
        }
        if (!string.IsNullOrEmpty(name))
        {
            rooms = rooms.Where(p => p.Name!.Contains(name));
        }
        if (cost.HasValue)
        {
           rooms = rooms.Where(p => p.Cost == cost);
        }
        if (square.HasValue)
        {
            rooms = rooms.Where(p => p.Square == square);
        }
        List<Room?> personsCount = db.room.GroupBy(u => u.PersonCount).Select(u => u.FirstOrDefault()).ToList();
        
        // пагинация
        var count = rooms.Count();
        rooms = rooms.Skip((page - 1) * pageSize).Take(pageSize);

        RoomListViewModel viewModel = new RoomListViewModel
        {
            Rooms = rooms,
            PersonsCount = new SelectList(personsCount, "PersonCount", "PersonCount", personCount),
            Name = name,
            Cost = cost,
            Square = square,
            PageViewModel = new PageViewModel(count, page, pageSize),
        };

        ViewData["IdSort"] = sortOrder == RoomsSortState.IdAsc ? RoomsSortState.IdDesc : RoomsSortState.IdAsc;
        ViewData["NameSort"] = sortOrder == RoomsSortState.NameAsc ? RoomsSortState.NameDesc : RoomsSortState.NameAsc;
        ViewData["DescriptionSort"] = sortOrder == RoomsSortState.DescriptionAsc ? RoomsSortState.DescriptionDesc : RoomsSortState.DescriptionAsc;
        ViewData["PersonCountSort"] = sortOrder == RoomsSortState.PersonCountAsc ? RoomsSortState.PersonCountDesc : RoomsSortState.PersonCountAsc;
        ViewData["SquareSort"] = sortOrder == RoomsSortState.SquareAsc ? RoomsSortState.SquareDesc : RoomsSortState.SquareAsc;
        ViewData["CostSort"] = sortOrder == RoomsSortState.CostAsc ? RoomsSortState.CostDesc : RoomsSortState.CostAsc;
        ViewData["HotelIdSort"] = sortOrder == RoomsSortState.HotelIdAsc ? RoomsSortState.HotelIdDesc : RoomsSortState.HotelIdAsc;

        viewModel.Rooms = sortOrder switch
        {
            //SortState.IdAsc => users.OrderByDescending(s => s.Id),
            RoomsSortState.IdDesc => viewModel.Rooms.OrderByDescending(s => s.Id),

            RoomsSortState.NameAsc => viewModel.Rooms.OrderBy(s => s.Name),
            RoomsSortState.NameDesc => viewModel.Rooms.OrderByDescending(s => s.Name),

            RoomsSortState.DescriptionAsc => viewModel.Rooms.OrderBy(s => s.Description),
            RoomsSortState.DescriptionDesc => viewModel.Rooms.OrderByDescending(s => s.Description),

            RoomsSortState.PersonCountAsc => viewModel.Rooms.OrderBy(s => s.PersonCount),
            RoomsSortState.PersonCountDesc => viewModel.Rooms.OrderByDescending(s => s.PersonCount),

            RoomsSortState.SquareAsc => viewModel.Rooms.OrderBy(s => s.Square),
            RoomsSortState.SquareDesc => viewModel.Rooms.OrderByDescending(s => s.Square),

            RoomsSortState.CostAsc => viewModel.Rooms.OrderBy(s => s.Cost),
            RoomsSortState.CostDesc => viewModel.Rooms.OrderByDescending(s => s.Cost),

            RoomsSortState.HotelIdAsc => viewModel.Rooms.OrderBy(s => s.HotelId),
            RoomsSortState.HotelIdDesc => viewModel.Rooms.OrderByDescending(s => s.HotelId),

            _ => viewModel.Rooms.OrderBy(s => s.Id),
        };
        return View(viewModel);
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
