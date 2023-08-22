namespace hw_1.Models
{
    public class RoomsFeature
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public RoomsFeature(int id, int roomId, Room room)
        {
            Id = id;
            RoomId = roomId;
            Room = room;
        }
    }
}
