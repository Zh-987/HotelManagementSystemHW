namespace hw_1.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Elders { get; set; }
        public int Children { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }

        public Reservation(int id, DateTime checkIn, DateTime checkOut, int elders, int children, string userId, int roomId, User user, Room room)
        {
            Id = id;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Elders = elders;
            Children = children;
            UserId = userId;
            RoomId = roomId;
            User = user;
            Room = room;
        }

    }
}
