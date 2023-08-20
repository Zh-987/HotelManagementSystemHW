namespace HotelManagemnetSystemHW.Models
{
    public class RoomsFeatures
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public RoomsFeatures(int id, int featureId, int roomId, Room room)
        {
            Id = id;
            FeatureId = featureId;
            RoomId = roomId;
            Room = room;
        }
    }
}
