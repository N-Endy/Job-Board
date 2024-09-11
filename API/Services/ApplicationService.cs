using API.Data.Contracts.Repositories;
using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;

namespace API.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ApplicationDto> AddApplicationAsync(Application newApplication)
        {
            return await _applicationRepository.AddApplicationAsync(newApplication);
        }

        public async Task<List<ApplicationDto>> GetAllApplicationsAsync()
        {
            return await _applicationRepository.GetAllApplicationsAsync();
        }

        public async Task<ApplicationDto?> GetApplicationByIdAsync(int id)
        {
            return await _applicationRepository.GetApplicationByIdAsync(id);
        }

        public async Task<ApplicationDto?> DeleteApplicationAsync(int id)
        {
            return await _applicationRepository.DeleteApplicationAsync(id);
        }
    }
}