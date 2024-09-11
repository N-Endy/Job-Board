namespace UI.Contracts.Controllers
{
    public interface IJobPostController
    {
        Task CreateJobPostAsync();
        Task ViewJobPostsAsync();
    }
}