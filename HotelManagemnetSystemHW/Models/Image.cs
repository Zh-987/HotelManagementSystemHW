using HotelManagemnetSystemHW.Controllers;
using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан признак")]
        public bool IsMain { get; set; }

        [Required(ErrorMessage = "Не указан ID комнаты")]
        [Range(1, 1000, ErrorMessage = "ID комнаты должен быть от 1 до 1000")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        public Image(int id, string name, bool isMain, int roomId, Room? room)
        {
            Id = id;
            Name = name;
            IsMain = isMain;
            RoomId = roomId;
            Room = room;
        }

    }
}
