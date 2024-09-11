using UI.Data.Models;

namespace UI.Contracts.Services
{
    public interface IJobPostService
    {
        Task<JobPost?> CreateJobPostAsync(JobPost jobPost);
        Task<List<JobPost>?> GetAllJobPostsAsync();
    }
}