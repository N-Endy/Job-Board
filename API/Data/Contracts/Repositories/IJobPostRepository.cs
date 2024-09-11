using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Repositories
{
    public interface IJobPostRepository : IRepository<JobPost>
    {
        Task<List<JobPostDto>> GetAllJobPostsAsync();
        Task<JobPostDto?> GetJobPostByIdAsync(int id);
        Task<JobPostDto> AddJobPostAsync(JobPost newJobPost);
        Task<JobPostDto?> DeleteJobPostAsync(int id);
    }
}