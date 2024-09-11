using Spectre.Console;
using UI.Contracts.Controllers;
using UI.Contracts.Services;
using UI.Data.Models;
using UI.UserInteractions;

namespace UI.Controllers
{
    public class StaffController : IStaffController
    {
        private static Staff? _currentLoggedInStaff;
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public Staff? GetCurrentLoggedStaff()
        {
            return _currentLoggedInStaff;
        }

        public async Task<bool> LoginStaff()
        {
            try
            {
                var userDetails = Prompts.GetStaffLoginDetails();
                var loginDetails = await _staffService.GetStaffLoginDetails(userDetails.Username);

                if (loginDetails == null || loginDetails.Password != userDetails.Password)
                {
                    AnsiConsole.MarkupLine("[bold][red]Invalid username or password[/][/]");
                    return false;
                }

                var staff = _staffService.GetStaffByUsername(userDetails.Username);
                _currentLoggedInStaff = staff.Result;

                Console.Clear();
                AnsiConsole.MarkupLine($"[bold][green]Welcome [blue]{staff.Result?.FullName}[/]! You are now logged in as staff.[/][/]");

                return true;
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
                return false;
            }
        }

        public async Task RegisterStaffAsync()
        {
            var newStaff = Prompts.GetStaffDetails();
            try
            {
                var result = await _staffService.AddStaff(newStaff);

                if (result == null)
                {
                    AnsiConsole.MarkupLine("[bold][red]Failed to create staff[/][/]");
                    return;
                }

                Console.Clear();
                AnsiConsole.MarkupLine($"[bold][green]Staff [blue]{newStaff.FullName}[/] created successfully[/][/]");
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine($"[bold][red]{ex.Message}[/][/]");
            }
        }
    }
}