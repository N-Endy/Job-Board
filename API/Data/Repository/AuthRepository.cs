using API.Data.Contracts.Repositories;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class AuthRepository : Repository<Staff>, IAuthRepository
    {
        public AuthRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<LoginDto?> GetStaffByUsernameAsync(string username)
        {
            var staff = await GetAll()
                .FirstOrDefaultAsync(s => s.Username == username);

            return staff?.ConvertToLoginDto();
        }
    }
}