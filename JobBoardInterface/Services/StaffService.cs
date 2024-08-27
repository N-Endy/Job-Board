
using JobBoardInterface.Controllers;
using JobBoardInterface.Models;
using JobBoardInterface.UserInteractions;
using Spectre.Console;

namespace JobBoardInterface.Services
{
    public class StaffService
    {
        private static readonly StaffController _staffController = new();
        private static Staff? _currentLoggedInStaff;


        internal static async Task<bool> LoginStaff()
        {
            var login = Prompts.GetLoginDetails();
            var staff = await _staffController.GetStaffLogin(login[0]);
            if (staff != null && staff.UserName == login[0] && staff.Password == login[1])
            {
                _currentLoggedInStaff = staff;
                return true;
            }
            else
            {
                AnsiConsole.Markup("[bold][red]Invalid credentials. Please try again.[/][/]\n\n");
                return false;
            }
        }

        internal static async Task RegisterStaff()
        {
            var staff = Prompts.GetStaffDetails();
            await AddStaffAsync(staff);
            AnsiConsole.Markup("[bold][green]Staff user created successfully[/][/]\n\n");
        }

        private static async Task AddStaffAsync(Staff staff)
        {
            await _staffController.Add(staff);
        }

        public static Staff? GetCurrentLoggedInStaff()
        {
            return _currentLoggedInStaff;
        }
    }
}