using UI.Data.Models;

namespace UI.Contracts.Services
{
    public interface IStaffService
    {
        Task<Staff?> AddStaff(Staff staff);
        Task<Staff?> GetStaffByUsername(string username);
        Task<LoginDetails?> GetStaffLoginDetails(string username);
    }
}