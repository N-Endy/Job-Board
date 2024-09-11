using UI.Data.Models;

namespace UI.Contracts.Controllers
{
    public interface IApplicantController
    {
        public Applicant? GetCurrentLoggedApplicant();
        Task GetApplicantByFullName();
        Task ApplyForJobPostAsync();
        Task AddNewApplicant(string applicantName);
        Task ViewAllApplicantsAsync();
        public void GetAllApplications();
    }
}