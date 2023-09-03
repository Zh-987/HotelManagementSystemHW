using System.ComponentModel.DataAnnotations;

namespace HotelManagemnetSystemHW.Models
{
    public enum RoleEnum
    {
        user=1,
        manager,
        admin
    }

    public class User
    {
        [Display(Name = "ID пользователя")]
        [Required(ErrorMessage = "Не указан Id пользователя")]
        public string Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Fullname { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Логин должен быть от 2 до 50 символов")]
        public string Username { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 50 символов")]
        public string Password { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не указан пол")]
        public string Sex { get; set; }

        [Display(Name = "Электронный адрес")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Не указан эл.адрес")]
        [EmailAddress(ErrorMessage = "Некорректный эл.адрес")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Не указан телефон")]
        [Phone(ErrorMessage = "Некорректный телефон")]
        public string Phone { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Не указана страна")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Страна должна быть от 2 до 50 символов")]
        public string Country { get; set; }

        public RoleEnum? Role { get; set; }

        public User()
        {
        }

        public User(string id, string fullname, string username, string password, DateTime dateOfBirth, string sex, string email, string phone, string country, RoleEnum role = RoleEnum.user)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            Email = email;
            Phone = phone;
            Country = country;
            Role = role;
        }
    }
}
