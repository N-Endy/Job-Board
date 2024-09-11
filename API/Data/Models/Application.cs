using API.Data.DTOs;
using API.Data.Enums;

namespace API.Data.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobPostId { get; set; }
        public required string JobTitle { get; set; }
        public JobPost? JobPost { get; set; }
        public int ApplicantId { get; set; }
        public required string ApplicantFullName { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public int StaffId { get; set; }
        public required string AssignedStaffName { get; set; }

        public ApplicationDto ConvertToApplicationDto() =>
        new()
        {
            ApplicationId = this.ApplicationId,
            JobPostId = this.JobPostId,
            JobTitle = this.JobTitle,
            ApplicantId = this.ApplicantId,
            ApplicantFullName = this.ApplicantFullName,
            ApplicationStatus = this.ApplicationStatus,
            StaffId = this.StaffId,
            AssignedStaffName = this.AssignedStaffName
        };
    }
}