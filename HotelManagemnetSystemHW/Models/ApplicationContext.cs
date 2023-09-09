using HotelManagemnetSystemHW.Areas.User.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelManagemnetSystemHW.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Hotel> hotels { get; set; } = null!;
        public DbSet<Image> images { get; set; } = null!;
        public DbSet<Reservation> reservation { get; set; } = null!;
        public DbSet<Room> room { get; set; } = null!;
        public DbSet<RoomsFeatures> roomsFeatures { get; set; } = null!;
        public DbSet<User> users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
