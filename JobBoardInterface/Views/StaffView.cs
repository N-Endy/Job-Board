
using JobBoardInterface.Services;
using JobBoardInterface.UserInteractions;
using Spectre.Console;

namespace JobBoardInterface.Views
{
    public class StaffView
    {
        internal static async Task LoginMenu()
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select Login or Register")
                .AddChoices(
                    "Login",
                    "Register")
                .UseConverter(x => x.ToString())
            );

            switch (choice)
            {
                case "Login":
                    await Login();
                    break;
                case "Register":
                    await Register();
                    break;
            }    
        }

        private static async Task Register()
        {
            await StaffService.RegisterStaff();
        }

        private static async Task Login()
        {
            var answer = await StaffService.LoginStaff();
            if (answer)
            {
                await StaffMenu();
            }
            else
            {
                return;
            }
        }

        internal static async Task StaffMenu()
        {
            var isStaffViewRunning = true;

            while (isStaffViewRunning)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Shift Logger Workers Menu")
                .AddChoices(
                    "View Workers",
                    "Add Worker",
                    "Update Worker",
                    "Delete Worker",
                    "Go Back")
                .UseConverter(x => x.ToString())
                );
            }
        }
    }
}