using JobBoardInterface.Models;

namespace JobBoardInterface.Controllers;
public interface IJobPostController
{
    void CreateJobPost(JobPost jobPost);
    JobPost ViewJobPost(int id);
    List<JobPost> ViewAllJobPosts();
    void UpdateJobPost(JobPost jobPost);
    void DeleteJobPost(int id);
}