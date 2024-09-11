using API.Data.Contracts.Repositories;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<ApplicationDto> AddApplicationAsync(Application newApplication)
        {
            var application = await AddAsync(newApplication);
            return application.ConvertToApplicationDto();
        }

        public async Task<List<ApplicationDto>> GetAllApplicationsAsync()
        {
            return await GetAll()
                .Select(a => a.ConvertToApplicationDto())
                .ToListAsync();
        }

        public async Task<ApplicationDto?> GetApplicationByIdAsync(int id)
        {
            var application = await GetAll()
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            return application?.ConvertToApplicationDto();
        }

        public async Task<ApplicationDto?> DeleteApplicationAsync(int id)
        {
            var application = await GetAll()
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application != null)
                Delete(application);
                return application?.ConvertToApplicationDto();
        }
    }
}