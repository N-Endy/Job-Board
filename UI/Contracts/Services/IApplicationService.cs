using UI.Data.Models;

namespace UI.Contracts.Services
{
    public interface IApplicationService
    {
        Task<Application?> AddApplication(Application newApplication);
    }
}