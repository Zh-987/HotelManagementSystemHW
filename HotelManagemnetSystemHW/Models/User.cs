namespace HotelManagemnetSystemHW.Models {
    public class User {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool RememberMe { get; set; }
    }

    public class Role {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public enum UserRole {
        User = 1,
        Manager = 2,
        Admin = 3
    }
}
