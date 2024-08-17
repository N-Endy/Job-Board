using Spectre.Console;

namespace JobBoardInterface.Views;
public class MainMenu
{
    public async Task ShowMainMenu()
    {
        bool isAppRunning = true;

        while (isAppRunning)
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("JobBoard Main Menu")
                    .AddChoices(
                        "Applicant",
                        "Staff",
                        "Exit")
                    .UseConverter(x => x.ToString())
                );

                switch (choice)
                {
                    case "Applicant":
                        await ApplicantView.ApplicantMenu();
                        break;
                    case "Staff":
                        await StaffView.LoginMenu();
                        break;
                    case "Exit":
                        isAppRunning = false;
                        Console.Clear();
                        AnsiConsole.MarkupLine("[bold][red]Exiting...[/][/]");
                        Environment.Exit(0);
                        break;
                }
        }
    }
}