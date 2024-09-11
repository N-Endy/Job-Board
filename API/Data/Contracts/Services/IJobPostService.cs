using API.Data.DTOs;
using API.Data.Models;

namespace API.Data.Contracts.Services
{
    public interface IJobPostService
    {
        Task<List<JobPostDto>> GetAllJobPostsAsync();
        Task<JobPostDto?> GetJobPostByIdAsync(int id);
        Task<JobPostDto> AddJobPostAsync(JobPost newJobPost);
        Task<JobPostDto?> DeleteJobPostAsync(int id);
    }
}