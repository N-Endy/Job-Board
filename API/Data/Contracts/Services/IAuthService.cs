using API.Data.DTOs;

namespace API.Data.Contracts.Services
{
    public interface IAuthService
    {
        // Task<LoginDto?> GetStaffByUsername(string username);
        // Task<LoginDto> LoginAsync(string username, string password);

        public Task<LoginDto?> GetStaffByUsernameAsync(string username);
    }
}