using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Services
{
    public interface IApplicationService
    {
        Task<List<ApplicationDto>> GetAllApplicationsAsync();
        Task<ApplicationDto?> GetApplicationByIdAsync(int id);
        Task<ApplicationDto> AddApplicationAsync(Application newApplication);
        Task<ApplicationDto?> DeleteApplicationAsync(int id);
    }
}