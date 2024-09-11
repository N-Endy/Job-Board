using UI.Data.Enums;

namespace UI.Data.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string FullName { get; set; } = "";
        public UserType UserType { get; set; } = UserType.Applicant;
        public List<Application> Applications { get; set; } = [];
    }
}