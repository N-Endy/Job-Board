using Spectre.Console;
using UI.Contracts.Views;

namespace UI.Views
{
    public class MainMenu
    {
        private readonly IStaffView _staffView;
        private readonly IApplicantView _applicantView;

        public MainMenu(IStaffView staffView, IApplicantView applicantView)
        {
            _staffView = staffView;
            _applicantView = applicantView;
        }
        
        public async Task ShowMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Clear();
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[bold][blue]JobBoard Main Menu[/][/]")
                    .AddChoices(
                        "Applicant",
                        "Staff",
                        "Exit"
                    )
                );

                switch (choice)
                {
                    case "Applicant":
                        await _applicantView.MenuAsync();
                        break;
                    case "Staff":
                        await _staffView.LoginMenuAsync();
                        break;
                    case "Exit":
                        isAppRunning = false;
                        Console.Clear();
                        AnsiConsole.MarkupLine("[bold][magenta]Exiting...[/][/]");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}