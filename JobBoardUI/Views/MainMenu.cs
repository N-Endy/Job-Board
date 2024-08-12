using Spectre.Console;

namespace JobBoardUI.Views;
public class MainMenu
{
    public async Task ShowMainMenu()
    {
        bool isAppRunning = true;

        if (isAppRunning)
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
                    case "Manage Workers":
                        await ApplicantMenu();
                        break;
                    case "Manage Shifts":
                        await StaffMenu();
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