using API.Data.Contracts.Repositories;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<ApplicantDto> AddApplicantAsync(Applicant newApplicant)
        {
            var applicant = await AddAsync(newApplicant);
            return applicant.ConvertToApplicantDto();
        }

        public async Task<List<ApplicantDto>> GetAllApplicantsAsync()
        {
            return await GetAll()
                .Include(a => a.Applications)
                .Select(a => a.ConvertToApplicantDto())
                .ToListAsync();
        }

        public async Task<ApplicantDto?> GetApplicantByIdAsync(int id)
        {
            var applicant = await GetAll()
                .Include(a => a.Applications)
                .FirstOrDefaultAsync(a => a.ApplicantId == id);

            return applicant?.ConvertToApplicantDto();
        }

        public async Task<ApplicantDto?> GetApplicantByFullNameAsync(string fullName)
        {
            var applicant = await GetAll()
                .Include(a => a.Applications)
                .FirstOrDefaultAsync(a => a.FullName == fullName);

            return applicant?.ConvertToApplicantDto();
        }

        public async Task<ApplicantDto?> DeleteApplicantAsync(int id)
        {
            var applicant = await GetAll()
                .FirstOrDefaultAsync(a => a.ApplicantId == id);

            if (applicant != null)
                Delete(applicant);
                return applicant?.ConvertToApplicantDto();
        }
    }
}