using API.Data.Contracts.Repositories;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<List<StaffDto>> GetAllStaffAsync()
        {
            return await GetAll()
                .Include(s => s.JobPosts)
                .Select(s => s.CovertStaffToStaffDto())
                .ToListAsync();
        }

        public async Task<StaffDto?> GetStaffByIdAsync(int id)
        {
            var staff = await GetAll()
                .Include(s => s.JobPosts)
                .FirstOrDefaultAsync(s => s.StaffId == id);

            return staff?.CovertStaffToStaffDto();
        }

        public async Task<StaffDto?> GetStaffByUsernameAsync(string username)
        {
            var staff = await GetAll()
                .FirstOrDefaultAsync(s => s.Username == username);

            return staff?.CovertStaffToStaffDto();
        }

        public async Task<StaffDto?> GetStaffByFullNameAsync(string fullName)
        {
            var staff = await GetAll()
                .FirstOrDefaultAsync(s => s.FullName == fullName);

            return staff?.CovertStaffToStaffDto();
        }

        public async Task<LoginDto?> GetStaffLoginDetailsAsync(string username)
        {
            var staff = await GetAll()
                .SingleAsync(s => s.Username == username);

            return new LoginDto
            {
                Username = staff.Username,
                Password = staff.Password
            };
        }

        public async Task<StaffDto> AddStaffAsync(Staff newStaff)
        {
            var staff = await AddAsync(newStaff);
            return staff.CovertStaffToStaffDto();
        }

        public async Task<StaffDto> UpdateStaffAsync(Staff newStaff)
        {
            var updatedStaff = await UpdateAsync(newStaff);

            return updatedStaff.CovertStaffToStaffDto();
        }

        public async Task<StaffDto?> DeleteStaffAsync(int id)
        {
            var staff = await GetAll()
                .FirstOrDefaultAsync(s => s.StaffId == id);
            
            if (staff != null)
                Delete(staff);
                return staff?.CovertStaffToStaffDto();
        }
    }
}