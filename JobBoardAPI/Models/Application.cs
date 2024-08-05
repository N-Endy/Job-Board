using System.ComponentModel.DataAnnotations.Schema;
using JobBoardAPI.Enums;

namespace JobBoardAPI.Models
{
    public class Application
    {
        public string ApplicationId { get; set; }
        public int JobPostId { get; set; }
        [ForeignKey(nameof(JobPostId))]
        public JobPost JobPost { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }
        public ApplicationStatus Status { get; set; }
        public int AssignedStaffId { get; set; }
        [ForeignKey(nameof(AssignedStaffId))]
        public Staff AssignedStaff { get; set; }
    }
}