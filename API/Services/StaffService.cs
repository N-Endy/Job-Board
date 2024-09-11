using API.Data.Contracts.Repositories;
using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;

namespace API.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<List<StaffDto>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllStaffAsync();
        }

        public async Task<StaffDto?> GetStaffByIdAsync(int id)
        {
            return await _staffRepository.GetStaffByIdAsync(id);
        }

        public async Task<StaffDto?> GetStaffByUsernameAsync(string username)
        {
            return await _staffRepository.GetStaffByUsernameAsync(username);
        }

        public async Task<StaffDto?> GetStaffByFullNameAsync(string fullName)
        {
            return await _staffRepository.GetStaffByFullNameAsync(fullName);
        }

        public async Task<LoginDto?> GetStaffLoginDetailsAsync(string username)
        {
            return await _staffRepository.GetStaffLoginDetailsAsync(username);
        }

        public async  Task<StaffDto> AddStaffAsync(Staff staff)
        {
            return await _staffRepository.AddStaffAsync(staff);
        }

        public async Task<StaffDto> UpdateStaffAsync(Staff newStaff)
        {
            return await _staffRepository.UpdateStaffAsync(newStaff);
        }

        public async Task<StaffDto?> DeleteStaffAsync(int id)
        {
            return await _staffRepository.DeleteStaffAsync(id);
        }
    }
}