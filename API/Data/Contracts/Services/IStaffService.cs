using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Services
{
    public interface IStaffService
    {
        Task<List<StaffDto>> GetAllStaffAsync();
        Task<StaffDto?> GetStaffByIdAsync(int id);
        Task<StaffDto?> GetStaffByUsernameAsync(string username);
        Task<StaffDto?> GetStaffByFullNameAsync(string fullName);
        Task<LoginDto?> GetStaffLoginDetailsAsync(string username);
        Task<StaffDto> AddStaffAsync(Staff newStaff);
        Task<StaffDto> UpdateStaffAsync(Staff newStaff);
        Task<StaffDto?> DeleteStaffAsync(int id);
    }
}