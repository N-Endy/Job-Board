using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Repositories
{
    public interface IAuthRepository : IRepository<Staff>
    {
        Task<LoginDto?> GetStaffByUsernameAsync(string username);
    }
}