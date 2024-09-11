using API.Data.Models;

namespace API.Data.DTOs
{
    public class JobPostDto
    {
        public int JobPostId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int StaffId { get; set; }
        public required string StaffFullName { get; set; }
        public ICollection<ApplicationDto> Applications { get; set; } = [];
    }
}