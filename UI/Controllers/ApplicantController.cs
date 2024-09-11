using Spectre.Console;
using UI.Contracts.Controllers;
using UI.Contracts.Services;
using UI.Data.Enums;
using UI.Data.Models;
using UI.UserInteractions;

namespace UI.Controllers
{
    public class ApplicantController : IApplicantController
    {
        private static Applicant? _currentLoggedApplicant;
        private readonly IApplicantService _applicantService;
        private readonly IJobPostService _jobPostService;
        private readonly IApplicationService _applicationService;

        public ApplicantController(IApplicantService applicantService, IJobPostService jobPostService, IApplicationService applicationService)
        {
            _applicantService = applicantService;
            _jobPostService = jobPostService;
            _applicationService = applicationService;
        }

        public Applicant? GetCurrentLoggedApplicant()
        {
            return _currentLoggedApplicant;
        }

        public async Task ApplyForJobPostAsync()
        {
            var jobPosts = await _jobPostService.GetAllJobPostsAsync();
            if (jobPosts == null)
            {
                AnsiConsole.MarkupLine("[bold][red]Failed to retrieve job posts.[/][/]");
                return;
            }

            if (jobPosts.Count == 0)
            {
                AnsiConsole.MarkupLine("[bold][red]No job posts found.[/][/]");
                return;
            }

            var selectedJobPost = Prompts.ShowJobPostOptions(jobPosts);

            if (selectedJobPost.Title == "Back")
            {
                return;
            }

            var applicant = _currentLoggedApplicant;

            if (applicant == null)
            {
                AnsiConsole.MarkupLine("[bold][red]No applicant is currently logged in.[/][/]");
                return;
            }

            var existingApplication = applicant.Applications.FirstOrDefault(a => a.JobPostId == selectedJobPost.JobPostId);

            if (existingApplication != null)
            {
                AnsiConsole.MarkupLine("[bold][red]You have already applied for this job post.[/][/]");
                return;
            }

            var application = new Application
            {
                JobPostId = selectedJobPost.JobPostId,
                JobTitle = selectedJobPost.Title,
                ApplicantId = applicant.ApplicantId,
                ApplicantFullName = applicant.FullName,
                ApplicationStatus = ApplicationStatus.Pending,
                StaffId = selectedJobPost.StaffId,
                AssignedStaffName = selectedJobPost.StaffFullName,
            };

            var addApplicationResult = await _applicationService.AddApplication(application);

            if (addApplicationResult == null || addApplicationResult.ApplicationId == 0)
            {
                AnsiConsole.MarkupLine("[bold][red]Failed to submit application.[/][/]");
                return;
            }

            applicant.Applications.Add(addApplicationResult);
            AnsiConsole.MarkupLine("[bold][green]Application submitted successfully.[/][/]");
        }

        public async Task GetApplicantByFullName()
        {
            try
            {
                var applicantFullName = Prompts.GetApplicantDetails();
                var applicantDetails = await _applicantService.GetApplicantByFullName(applicantFullName);

                // New Applicant
                if (applicantDetails is null)
                {
                    await AddNewApplicant(applicantFullName);
                }
                else
                {
                    _currentLoggedApplicant = applicantDetails;
                    AnsiConsole.MarkupLine($"[bold][green]Welcome [blue]{applicantDetails.FullName}[/]! You are now logged in as an applicant.[/][/]");
                }
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message == "An error occurred: Resource not found.")
                {
                    AnsiConsole.MarkupLine("[bold][green]Applicant not found. Creating new applicant...[/][/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
                }
            }
        }

        public async Task AddNewApplicant(string applicantName)
        {
            var newApplicant = new Applicant
            {
                FullName = applicantName,
                UserType = UserType.Applicant,
            };
            var newApplicantDetails = await _applicantService.AddApplicant(newApplicant);

            if (newApplicantDetails != null)
            {
                _currentLoggedApplicant = newApplicantDetails;
                AnsiConsole.MarkupLine($"[bold][green]New applicant created: {newApplicantDetails.FullName}[/][/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold][red]Failed to create new applicant.[/][/]");
            }
        }

        public void GetAllApplications()
        {
            try
            {
                var applicant = _currentLoggedApplicant;

                if (applicant == null)
                {
                    AnsiConsole.MarkupLine("[bold][red]No applicant is currently logged in.[/][/]");
                    return;
                }

                var applications = applicant.Applications;

                if (applications.Count == 0)
                {
                    AnsiConsole.MarkupLine("[bold][red]No applications found for this applicant.[/][/]");
                    return;
                }

                Prompts.DisplayApplicantApplicationTable(applications);
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
            }
        }

        public async Task ViewAllApplicantsAsync()
        {
            try
            {
                var applicants = await _applicantService.GetAllApplicantsAsync();

                if (applicants == null || applicants.Count == 0)
                {
                    AnsiConsole.MarkupLine("[bold][red]No applicants found.[/][/]");
                    return;
                }

                Prompts.DisplayAllApplicantsTable(applicants);
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
            }
        }
    }
}