using System.Net.Http.Json;
using Spectre.Console;
using UI.Contracts.Services;
using UI.Data.Models;
using UI.Utilities;

namespace UI.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly HttpClient? _httpClient = new();
        private readonly string? _baseUrl = "https://localhost:7107";

        public async Task<Applicant?> GetApplicantByFullName(string fullName)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/applicants/find/{fullName}");
                return await ApiResponseHandler.HandleResponse<Applicant>(response);
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

        public async Task<Applicant?> AddApplicant(Applicant newApplicant)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/applicants", newApplicant);
                return await ApiResponseHandler.HandleResponse<Applicant>(response);
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

        public async Task<List<Applicant>?> GetAllApplicantsAsync()
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/applicants");
                return await ApiResponseHandler.HandleResponse<List<Applicant>>(response);
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