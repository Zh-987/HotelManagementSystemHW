using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано фото")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Описание должно быть от 2 до 255 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указан рейтинг")]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }

        public List<Room>? Rooms { get; set; }

        public Hotel(int id, string name, string image, string description, int rating, List<Room>? rooms)
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
