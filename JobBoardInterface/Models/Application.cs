using JobBoardAPI.Enums;

namespace JobBoardInterface.Models;

public class Application
    {
        public int ApplicationId { get; set; }
        public int JobPostId { get; set; }
        public JobPost? JobPost { get; set; }
        public int ApplicantId { get; set; }
        public Applicant? Applicant { get; set; }
        public ApplicationStatus Status { get; set; }
        public int AssignedStaffId { get; set; }
        public Staff? AssignedStaff { get; set; }
    }