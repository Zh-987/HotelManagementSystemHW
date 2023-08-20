namespace HotelManagemnetSystemHW.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonCount { get; set; }
        public int Square { get; set; }
        public double Cost { get; set; }
        public List<RoomsFeatures> RoomFeatures { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Image> Images { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Room(int id, string name, string description, int personCount, int square, double cost, List<RoomsFeatures> roomFeatures, int hotelId, Hotel hotel, List<Image> images, List<Reservation> reservations)
        {
            Id = id;
            Name = name;
            Description = description;
            PersonCount = personCount;
            Square = square;
            Cost = cost;
            RoomFeatures = roomFeatures;
            HotelId = hotelId;
            Hotel = hotel;
            Images = images;
            Reservations = reservations;
        }


    }
}
