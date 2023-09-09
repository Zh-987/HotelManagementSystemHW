using HotelManagemnetSystemHW.Controllers;
using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public class Reservation
    {

        public int Id { get; set; }

        [Display(Name = "Дата заселения")]
        [Required(ErrorMessage = "Не указано дата заселения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Дата выселения")]
        [Required(ErrorMessage = "Не указано дата выселения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }

        [Display(Name = "Количество взрослых")]
        [Required(ErrorMessage = "Не указано количество взрослых")]
        [Range(1, 10, ErrorMessage = "Количество взрослых должно быть от 1 до 10")]
        public int Elders { get; set; }

        [Display(Name = "Количество детей")]
        [Required(ErrorMessage = "Не указано количество детей")]
        [Range(1, 10, ErrorMessage = "Количество детей должно быть от 1 до 10")]
        public int Children { get; set; }

        [Display(Name = "ID пользователя")]
        [Required(ErrorMessage = "Не указан ID пользователя")]
        public string UserId { get; set; }

        [Display(Name = "ID комнаты")]
        [Required(ErrorMessage = "Не указан ID комнаты")]
        [Range(1, 1000, ErrorMessage = "ID комнаты должен быть от 1 до 1000")]
        public int RoomId { get; set; }

        public User? User { get; set; }

        public Room? Room { get; set; }

        public Reservation() { }

        public Reservation(int id, DateTime checkIn, DateTime checkOut, int elders, int children, string userId, int roomId, User? user, Room? room)
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
