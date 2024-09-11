using UI.Data.Models;

namespace UI.Contracts.Controllers
{
    public interface IStaffController
    {
        public Staff? GetCurrentLoggedStaff();
        Task RegisterStaffAsync();
        Task<bool> LoginStaff();
    }
}