using API.Data.Enums;
using API.Data.Models;

namespace API.Data.DTOs
{
    public class StaffDto
    {
        public int StaffId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public UserType UserType { get; set; }
        public ICollection<JobPostDto> JobPosts { get; set; } = [];
    }
}