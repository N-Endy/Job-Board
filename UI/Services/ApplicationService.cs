using System.Net.Http.Json;
using Spectre.Console;
using UI.Contracts.Services;
using UI.Data.Models;
using UI.Utilities;

namespace UI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly HttpClient? _httpClient = new();
        private readonly string? _baseUrl = "https://localhost:7107";

        public async Task<Application?> AddApplication(Application newApplication)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/applications", newApplication);
                return await ApiResponseHandler.HandleResponse<Application>(response);
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