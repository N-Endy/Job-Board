
using UI.Data.Models;
using Spectre.Console;
using UI.Data.Enums;

namespace UI.UserInteractions
{
    public class Prompts
    {
        internal static void DisplayAllApplicantsTable(List<Applicant> applicants)
        {
            var table = new Table()
                .AddColumn("No")
                .AddColumn("Full Name");

            int count = 1;
            foreach (var applicant in applicants)
            {
                table.AddRow(
                    count.ToString(),
                    applicant.FullName.ToString()
                );
            }

            AnsiConsole.Write(table);
        }

        internal static void DisplayApplicantApplicationTable(List<Application> applications)
        {
            var table = new Table()
                .AddColumn("No")
                .AddColumn("Job Post Title")
                .AddColumn("Application Status");

            int count = 1;
            foreach (var application in applications)
            {
                table.AddRow(
                    count.ToString(),
                    application.JobTitle.ToString(),
                    application.ApplicationStatus.ToString()
                );
            }

            AnsiConsole.Write(table);
        }

        internal static void DisplayJobPosts(List<JobPost> jobPosts)
        {
            var table = new Table()
                .AddColumn("No")
                .AddColumn("Title")
                .AddColumn("Description")
                .AddColumn("Staff");

            int count = 1;
            foreach (var jobPost in jobPosts)
            {
                table.AddRow(
                    count.ToString(),
                    jobPost.Title.ToString(),
                    jobPost.Description.ToString(),
                    jobPost.StaffFullName.ToString()
                );
            }

            AnsiConsole.Write(table);
        }

        internal static string GetApplicantDetails()
        {
            var fullName = AnsiConsole.Prompt(new TextPrompt<string>("[bold]Enter [green]FullName[/][/]:"));

            return fullName;
        }

        internal static JobPost GetJobPostDetails()
        {
            var title = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Title[/][/]:"));

            var description = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Description[/][/]:"));

            return new JobPost
            {
                Title = title,
                Description = description,
            };
        }

        internal static Staff GetStaffDetails()
        {
            var fullName = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]FullName[/][/]:"));

            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Username[/][/]:"));

            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Password[/][/]:"));

            return new Staff
            {
                FullName = fullName,
                Username = username,
                Password = password,
                UserType = UserType.Staff
            };
        }

        internal static LoginDetails GetStaffLoginDetails()
        {
            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Username[/][/]:"));

            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Password[/][/]:"));

            return new LoginDetails
            {
                Username = username,
                Password = password
            };
        }

        internal static JobPost ShowJobPostOptions(List<JobPost> jobPosts)
        {
            jobPosts.Insert(0, new JobPost { Title = "Back" });

            var selectedJobPost = AnsiConsole.Prompt(
                new SelectionPrompt<JobPost>()
                    .Title("[bold]Select a Job Post:[/]")
                    .AddChoices(jobPosts)
                    .UseConverter(jobPost => jobPost.Title ?? "No Title")
                    .PageSize(10)
            );

            return selectedJobPost;
        }
    }
}