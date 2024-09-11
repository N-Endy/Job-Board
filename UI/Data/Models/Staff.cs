using UI.Data.Enums;

namespace UI.Data.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public UserType UserType { get; set; } = UserType.Staff;
        public ICollection<JobPost> JobPosts { get; set; } = [];
    }
}