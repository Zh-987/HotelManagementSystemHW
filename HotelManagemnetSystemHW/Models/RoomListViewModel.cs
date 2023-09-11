using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelManagemnetSystemHW.Models
{
    public class RoomListViewModel
    {
        public IQueryable<Room>? Rooms { get; set; }
        public SelectList PersonsCount { get; set; } = new SelectList(new List<Room>(), "PersonCount", "PersonCount");
        public string? Name { get; set; }
        public double? Cost { get; set; }
        public int? Square { get; set; }
        public PageViewModel? PageViewModel { get; set; }

    }
}
