using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<List<ApplicationDto>> GetAllApplicationsAsync();
        Task<ApplicationDto?> GetApplicationByIdAsync(int id);
        Task<ApplicationDto> AddApplicationAsync(Application newApplication);
        Task<ApplicationDto?> DeleteApplicationAsync(int id);
    }
}