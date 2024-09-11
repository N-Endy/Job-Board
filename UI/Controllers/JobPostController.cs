using Spectre.Console;
using UI.Contracts.Controllers;
using UI.Contracts.Services;
using UI.UserInteractions;

namespace UI.Controllers
{
    public class JobPostController : IJobPostController
    {
        private readonly IJobPostService _jobPostService;
        private readonly IStaffService _staffService;
        private readonly IStaffController _staffController;

        public JobPostController(IJobPostService jobPostService, IStaffService staffService, IStaffController staffController)
        {
            _jobPostService = jobPostService;
            _staffService = staffService;
            _staffController = staffController;
        }

        public async Task CreateJobPostAsync()
        {
            try
            {
                var jobPost = Prompts.GetJobPostDetails();
                var staff = _staffController.GetCurrentLoggedStaff();
                if (staff != null)
                {
                    jobPost.StaffId = staff.StaffId;
                    jobPost.StaffFullName = staff.FullName;
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold][red]Failed to get current logged staff[/][/]");
                    return;
                }
                
                var result = await _jobPostService.CreateJobPostAsync(jobPost);

                if (result == null)
                {
                    AnsiConsole.MarkupLine("[bold][red]Failed to create job post[/][/]");
                    return;
                }

                Console.Clear();
                AnsiConsole.MarkupLine($"[bold][green]Job post created successfully[/][/]");
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
            }
        }

        public Task ViewJobPostsAsync()
        {
            try
            {
                var jobPosts = _jobPostService.GetAllJobPostsAsync().Result;

                if (jobPosts == null || jobPosts.Count == 0)
                {
                    AnsiConsole.MarkupLine("[bold][red]No job posts found[/][/]");
                    return Task.CompletedTask;
                }

                Prompts.DisplayJobPosts(jobPosts);
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
            }

            return Task.CompletedTask;
        }
    }
}