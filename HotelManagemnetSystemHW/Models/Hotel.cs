namespace HotelManagemnetSystemHW.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public List<Room> Rooms { get; set; }

        public Hotel(int id, string name, string image, string description, int rating, List<Room> rooms)
        {
            Id = id;
            Name = name;
            Image = image;
            Description = description;
            Rating = rating;
            Rooms = rooms;
        }
    }
}
