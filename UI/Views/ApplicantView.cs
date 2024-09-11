using Spectre.Console;
using UI.Contracts.Controllers;
using UI.Contracts.Views;

namespace UI.Views
{
    public class ApplicantView : IApplicantView
    {
        private readonly IApplicantController _applicantController;

        public ApplicantView(IApplicantController applicantController)
        {
            _applicantController = applicantController;
        }

        public async Task MenuAsync()
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[bold][blue]Applicant Menu[/][/]")
                .AddChoices(
                    "Enter FullName",
                    "Back"
                )
            );

            switch (choice)
            {
                case "Enter FullName":
                    await _applicantController.GetApplicantByFullName();
                    await ApplicantMenuAsync();
                    break;
                case "Back":
                    return;
            }
        }

        public async Task ApplicantMenuAsync()
        {
            var isApplicantViewRunning = true;

            while (isApplicantViewRunning)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Applicant Menu")
                    .AddChoices(
                        "Apply for Jobs",
                        "View My Applications",
                        "Go Back")
                    .UseConverter(x => x.ToString())
                );

                switch (choice)
                {
                    case "Apply for Jobs":
                        await _applicantController.ApplyForJobPostAsync();
                        break;
                    case "View My Applications":
                        _applicantController.GetAllApplications();
                        break;
                    case "Go Back":
                        return;
                }
            }
        }
    }
}