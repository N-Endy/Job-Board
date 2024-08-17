using JobBoardInterface.Models;
using Spectre.Console;

namespace JobBoardInterface.UserInteractions
{
    public class Prompts
    {
        public static Staff GetStaffDetails()
        {
            var fullname = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Fullname[/][/]:"));

            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Username[/][/]:"));

            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Password[/][/]:"));

            return new Staff
            {
                FullName = fullname,
                UserName = username,
                Password = password
            };
        }

        internal static List<string> GetLoginDetails()
        {
            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Username[/][/]:"));
            
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Password[/][/]:"));

            return [username, password];
        }
    }
}