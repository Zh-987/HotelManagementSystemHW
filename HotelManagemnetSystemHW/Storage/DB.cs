using HotelManagemnetSystemHW.Models;

namespace HotelManagemnetSystemHW.Storage
{
    public static class DB
    {

        public static List<Room> GetHotelRooms()
        {
            return new List<Room>
            {
                new Room{Image = "https://www.travoh.com/wp-content/uploads/2021/10/062-The-Miami-Beach-EDITION-Hotel-Miami-Beach-FL-USA-City-View-Double-Room.jpg" , Number = 1, Price = 5000},
                new Room{Image = "https://www.travoh.com/wp-content/uploads/2021/10/062-The-Miami-Beach-EDITION-Hotel-Miami-Beach-FL-USA-City-View-Double-Room.jpg" , Number = 2, Price = 7000},
                new Room{Image = "https://www.travoh.com/wp-content/uploads/2021/10/062-The-Miami-Beach-EDITION-Hotel-Miami-Beach-FL-USA-City-View-Double-Room.jpg" , Number = 3, Price = 2000}
            };
        }

        public static Room GetRoom(int number) {
            return GetHotelRooms().FirstOrDefault(x => x.Number == number);
        }
    }
}
