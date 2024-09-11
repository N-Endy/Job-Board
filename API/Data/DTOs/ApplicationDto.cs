using API.Data.Enums;

namespace API.Data.DTOs
{
    public class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public int JobPostId { get; set; }
        public string JobTitle { get; set; } = "";
        public int ApplicantId { get; set; }
        public string ApplicantFullName { get; set; } = "";
        public ApplicationStatus ApplicationStatus { get; set; }
        public int StaffId { get; set; }
        public string AssignedStaffName { get; set; } = "";
    }
}