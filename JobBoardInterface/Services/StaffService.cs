
using JobBoardInterface.Controllers;
using JobBoardInterface.Models;
using JobBoardInterface.UserInteractions;
using Spectre.Console;

namespace JobBoardInterface.Services
{
    public class StaffService
    {
        private static readonly StaffController _staffController = new();

        internal static async Task<bool> LoginStaff()
        {
            var login = Prompts.GetLoginDetails();
            var staff = await _staffController.GetStaffLogin(login[0]);
            return staff != null && staff.UserName == login[0] && staff.Password == login[1];
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
    }
}