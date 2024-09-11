using UI.Data.Models;

namespace UI.Contracts.Services
{
    public interface IApplicantService
    {
        Task<Applicant?> AddApplicant(Applicant newApplicant);
        Task<Applicant?> GetApplicantByFullName(string fullName);
        Task<List<Applicant>?> GetAllApplicantsAsync();
    }
}