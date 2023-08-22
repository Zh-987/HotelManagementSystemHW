namespace hw_1.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Image(int id, string name, bool isMain, int roomId, Room room)
        {
            Id = id;
            Name = name;
            IsMain = isMain;
            RoomId = roomId;
            Room = room;
        }

    }
}
