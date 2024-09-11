using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Repositories
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<List<ApplicantDto>> GetAllApplicantsAsync();
        Task<ApplicantDto?> GetApplicantByIdAsync(int id);
        Task<ApplicantDto?> GetApplicantByFullNameAsync(string fullName);
        Task<ApplicantDto> AddApplicantAsync(Applicant newApplicant);
        Task<ApplicantDto?> DeleteApplicantAsync(int id);
    }
}