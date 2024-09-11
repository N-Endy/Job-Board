using API.Data.DTOs;

namespace API.Data.Models
{
    public class Staff : User
    {
        public int StaffId { get; set; }
        public ICollection<JobPost> JobPosts { get; set; } = [];

        public StaffDto CovertStaffToStaffDto() =>
        new()
        {
                StaffId = this.StaffId,
                Username = this.Username,
                FullName = this.FullName,
                UserType = this.UserType,
                JobPosts = this.JobPosts.Select(j => j.ConvertJobPostToJobPostDto()).ToList(),
        };

        public LoginDto ConvertToLoginDto() =>
        new()
        {
                Username = this.Username,
                Password = this.Password
        };
    }
}