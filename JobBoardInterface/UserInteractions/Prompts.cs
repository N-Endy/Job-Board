using JobBoardInterface.Models;
using JobBoardInterface.Services;
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

        internal static JobPost GetJobPostDetails()
        {
            //Get current staff
            var staff = StaffService.GetCurrentLoggedInStaff();
            
            var title = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Enter Job Title[/][/]:"));

            var description = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold]Enter [green]Job Description[/][/]:"));

            return new JobPost
            {
                Title = title,
                Description = description,
                StaffId = staff.StaffId,
                Staff = staff
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

        internal static async void ShowAllJobPosts(IEnumerable<JobPost> jobPosts)
        {
            var table = new Table()
                .AddColumn("ID")
                .AddColumn("Title")
                .AddColumn("Description")
                .AddColumn("Staff");

            var staff = StaffService.GetCurrentLoggedInStaff();

            int count = 1;
            foreach (var jobPost in jobPosts)
            {
                table.AddRow(
                    count.ToString(),
                    jobPost.Title.ToString(),
                    jobPost.Description.ToString(),
                    staff.FullName.ToString()
                );
            }

            AnsiConsole.Write(table);
        }
    }
}