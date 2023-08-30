using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public class RoomsFeatures
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан FeatureId")]
        [Range(1, 1000, ErrorMessage = "FeatureId должен быть от 1 до 1000")]
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Не указан ID комнаты")]
        [Range(1, 1000, ErrorMessage = "ID комнаты должен быть от 1 до 1000")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        public RoomsFeatures(int id, int featureId, int roomId, Room? room)
        {
            Id = id;
            FeatureId = featureId;
            RoomId = roomId;
            Room = room;
        }
    }
}
