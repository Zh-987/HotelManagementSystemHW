using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelManagemnetSystemHW.Models
{
    public class UserListViewModel
    {
        public IQueryable<User>? Users { get; set; }
        public SelectList Countries { get; set; } = new SelectList(new List<User>(), "Country", "Country");
        public string? Username { get; set; }
        public RoleEnum? Role { get; set; }
        public PageViewModel? PageViewModel { get; set; }
    }
}
