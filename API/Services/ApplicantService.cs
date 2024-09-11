using API.Data.Contracts.Repositories;
using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;

namespace API.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<ApplicantDto> AddApplicantAsync(Applicant newApplicant)
        {
            return await _applicantRepository.AddApplicantAsync(newApplicant);
        }

        public async Task<List<ApplicantDto>> GetAllApplicantsAsync()
        {
            return await _applicantRepository.GetAllApplicantsAsync();
        }

        public async Task<ApplicantDto?> GetApplicantByIdAsync(int id)
        {
            return await _applicantRepository.GetApplicantByIdAsync(id);
        }

        public async Task<ApplicantDto?> GetApplicantByFullNameAsync(string fullName)
        {
            return await _applicantRepository.GetApplicantByFullNameAsync(fullName);
        }

        public async Task<ApplicantDto?> DeleteApplicantAsync(int id)
        {
            return await _applicantRepository.DeleteApplicantAsync(id);
        }
    }
}