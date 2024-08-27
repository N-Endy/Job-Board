using JobBoardInterface.Controllers;
using JobBoardInterface.Models;
using JobBoardInterface.UserInteractions;
using Spectre.Console;

namespace JobBoardInterface.Services;
public class JobPostService
{
    private static readonly JobPostController _staffController = new();

    internal static async Task<JobPost?> CreateJobPost(JobPost jobPost)
    {
        return await _staffController.CreateJobPost(jobPost);
    }

    internal static async Task ViewAllJobPosts()
    {
        var jobPosts = await _staffController.ViewAllJobPosts();

        if (jobPosts == null || !jobPosts.Any())
        {
            AnsiConsole.MarkupLine("[bold][red]No jobposts found.[/][/]");
            return;
        }

        Prompts.ShowAllJobPosts(jobPosts);
    }
}