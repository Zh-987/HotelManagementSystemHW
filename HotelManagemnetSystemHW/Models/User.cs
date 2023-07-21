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
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public RoleEnum Role { get; set; }

        public User(int id, string fullname, string username, string password, DateTime dateOfBirth, string sex, string email, string phone, string country, RoleEnum role = RoleEnum.user)
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
