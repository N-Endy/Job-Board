using API.Data.DTOs;

namespace API.Data.Models
{
    public class Applicant : User
    {
        public int ApplicantId { get; set; }
        public ICollection<Application> Applications { get; set; } = [];

        public ApplicantDto ConvertToApplicantDto() =>
        new()
        {
            ApplicantId = this.ApplicantId,
            FullName = this.FullName,
            Applications = this.Applications.Select(a => a.ConvertToApplicationDto()).ToList(),
        };
    }
}