using API.Data.Contracts.Repositories;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class JobPostRepository : Repository<JobPost>, IJobPostRepository
    {
        public JobPostRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<JobPostDto> AddJobPostAsync(JobPost newJobPost)
        {
            var jobPost = await AddAsync(newJobPost);
            return jobPost.ConvertJobPostToJobPostDto();
        }

        public async Task<List<JobPostDto>> GetAllJobPostsAsync()
        {
            return await GetAll()
                .Include(j => j.Applications)
                .Select(j => j.ConvertJobPostToJobPostDto())
                .ToListAsync();
        }

        public async Task<JobPostDto?> GetJobPostByIdAsync(int id)
        {
            var jobPost = await GetAll()
                .Include(j => j.Applications)
                .FirstOrDefaultAsync(j => j.JobPostId == id);

                return jobPost?.ConvertJobPostToJobPostDto();
        }

        public async Task<JobPostDto?> DeleteJobPostAsync(int id)
        {
            var jobPost = await GetAll()
                .FirstOrDefaultAsync(job => job.JobPostId == id);
            
            if (jobPost != null)
                Delete(jobPost);
                return jobPost?.ConvertJobPostToJobPostDto();
        }
    }
}