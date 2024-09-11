using API.Data.Contracts.Repositories;
using API.Data.Contracts.Services;
using API.Data.DTOs;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginDto?> GetStaffByUsernameAsync(string username)
        {
            return await _authRepository.GetStaffByUsernameAsync(username);
        }

        // public Task<LoginDto?> GetStaffByUsername(string username)
        // {
        //     return
        // }

        // public Task<LoginDto> LoginAsync(string username, string password)
        // {
        //     throw new NotImplementedException();
        // }
    }
}