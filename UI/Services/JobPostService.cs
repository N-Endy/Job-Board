using System.Net.Http.Json;
using Spectre.Console;
using UI.Contracts.Services;
using UI.Data.Models;
using UI.Utilities;

namespace UI.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _baseUrl = "https://localhost:7107";

        public async Task<JobPost?> CreateJobPostAsync(JobPost jobPost)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/jobposts", jobPost);
                return await ApiResponseHandler.HandleResponse<JobPost>(response);
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

        public async Task<List<JobPost>?> GetAllJobPostsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/jobposts");
                return await ApiResponseHandler.HandleResponse<List<JobPost>>(response);
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