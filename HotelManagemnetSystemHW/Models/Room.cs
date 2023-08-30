using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Описание должно быть от 2 до 255 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указан количество человек")]
        [Range(1, 30, ErrorMessage = "Количество человек должен быть от 1 до 30")]
        public int PersonCount { get; set; }

        [Required(ErrorMessage = "Не указана площадь")]
        [Range(1, 300, ErrorMessage = "Площадь должен быть от 1 до 300")]
        public int Square { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        [Range(1, 10000, ErrorMessage = "Цена должен быть от 1 до 10000")]
        public double Cost { get; set; }

        public List<RoomsFeatures>? RoomFeatures { get; set; }

        [Required(ErrorMessage = "Не указан ID отеля")]
        [Range(1, 100, ErrorMessage = "ID отеля должен быть от 1 до 100")]
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }

        public List<Image>? Images { get; set; }

        public List<Reservation>? Reservations { get; set; }

        public Room(int id, string name, string description, int personCount, int square, double cost, List<RoomsFeatures>? roomFeatures, int hotelId, Hotel? hotel, List<Image>? images, List<Reservation>? reservations)
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
