using Spectre.Console;
using UI.Contracts.Controllers;
using UI.Contracts.Views;

namespace UI.Views
{
    public class StaffView : IStaffView
    {
        private readonly IStaffController _staffController;
        private readonly IJobPostController _jobPostController;
        private readonly IApplicantController _applicantController;

        public StaffView(IStaffController staffController, IJobPostController jobPostController, IApplicantController applicantController)
        {
            _staffController = staffController;
            _jobPostController = jobPostController;
            _applicantController = applicantController;
        }

        public async Task LoginMenuAsync()
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[bold][blue]Staff Login Menu[/][/]")
                .AddChoices(
                    "Login",
                    "Register",
                    "Back"
                )
            );

            switch (choice)
            {
                case "Login":
                    await LoginStaffAsync();
                    break;
                case "Register":
                    await RegisterStaffAsync();
                    break;
                case "Back":
                    return;
            }
        }

        public async Task RegisterStaffAsync()
        {
            await _staffController.RegisterStaffAsync();
        }

        public async Task LoginStaffAsync()
        {
            var canLogin = await _staffController.LoginStaff();
            if (canLogin)
            {
                await StaffMenuAsync();
            }
            else
            {
                return;
            }
        }

        internal async Task StaffMenuAsync()
        {
            var isStaffViewRunning = true;

            while (isStaffViewRunning)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Staff Menu")
                .AddChoices(
                    "Create Job Post",
                    "View All Job Posts",
                    "View All Applicants",
                    "Go Back")
                .UseConverter(x => x.ToString())
                );

                switch (choice)
                {
                    case "Create Job Post":
                        await _jobPostController.CreateJobPostAsync();
                        break;
                    case "View All Job Posts":
                        await _jobPostController.ViewJobPostsAsync();
                        break;
                    case "View All Applicants":
                        await _applicantController.ViewAllApplicantsAsync();
                        break;
                    case "Go Back":
                        return;
                }
            }
        }
    }
}