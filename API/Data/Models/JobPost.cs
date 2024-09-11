using System.ComponentModel.DataAnnotations.Schema;
using API.Data.DTOs;

namespace API.Data.Models
{
    public class JobPost
    {
        public int JobPostId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int StaffId { get; set; }
        public required string StaffFullName { get; set; }
        public ICollection<Application> Applications { get; set; } = [];

        public JobPostDto ConvertJobPostToJobPostDto() =>
        new()
        {
            JobPostId = this.JobPostId,
            Title = this.Title,
            Description = this.Description,
            StaffId = this.StaffId,
            StaffFullName = this.StaffFullName,
            Applications = this.Applications.Select(a => a.ConvertToApplicationDto()).ToList()
        };
    }
}