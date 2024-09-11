using API.Data.Enums;

namespace API.Data.Models
{
    public class User
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public required string FullName { get; set; }
        public UserType UserType { get; set; }
    }
}