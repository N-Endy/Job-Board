using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Services
{
    public interface IApplicantService
    {
        Task<List<ApplicantDto>> GetAllApplicantsAsync();
        Task<ApplicantDto?> GetApplicantByIdAsync(int id);
        Task<ApplicantDto?> GetApplicantByFullNameAsync(string fullName);
        Task<ApplicantDto> AddApplicantAsync(Applicant newApplicant);
        Task<ApplicantDto?> DeleteApplicantAsync(int id);
    }
}