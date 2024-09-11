using API.Data.Contracts.Repositories;
using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;

namespace API.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostService(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }

        public async Task<JobPostDto> AddJobPostAsync(JobPost jobPost)
        {
            return await _jobPostRepository.AddJobPostAsync(jobPost);
        }

        public async Task<List<JobPostDto>> GetAllJobPostsAsync()
        {
            return await _jobPostRepository.GetAllJobPostsAsync();
        }

        public async Task<JobPostDto?> GetJobPostByIdAsync(int id)
        {
            return await _jobPostRepository.GetJobPostByIdAsync(id);
        }

        public async Task<JobPostDto?> DeleteJobPostAsync(int id)
        {
            return await _jobPostRepository.DeleteJobPostAsync(id);
        }
    }
}