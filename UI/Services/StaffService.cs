using System.Net.Http.Json;
using Spectre.Console;
using UI.Contracts.Services;
using UI.Data.Models;
using UI.Utilities;

namespace UI.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient? _httpClient = new();
        private readonly string? _baseUrl = "https://localhost:7107";

        public async Task<Staff?> AddStaff(Staff staff)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/staffs", staff);
                return await ApiResponseHandler.HandleResponse<Staff>(response);
            }
            catch (HttpRequestException ex)
            {
                HandleException(ex);
                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<Staff?> GetStaffByUsername(string username)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/staffs/{username}");
                return await ApiResponseHandler.HandleResponse<Staff>(response);
            }
            catch (HttpRequestException ex)
            {
                HandleException(ex);
                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<LoginDetails?> GetStaffLoginDetails(string username)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/staffs/find/{username}");

                return await ApiResponseHandler.HandleResponse<LoginDetails>(response);
            }
            catch (HttpRequestException ex)
            {
                HandleException(ex);
                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        private static void HandleException(Exception ex)
        {
            AnsiConsole.MarkupLine($"[bold][red]An error occurred: {ex.Message}[/][/]");
        }
    }
}