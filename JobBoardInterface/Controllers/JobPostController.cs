using System.Net.Http.Json;
using JobBoardInterface.Models;
using JobBoardInterface.Utilities;

namespace JobBoardInterface.Controllers;
public class JobPostController
{
    private readonly HttpClient _httpClient = new();
    private readonly string _baseUrl = "https://localhost:7107";

    public async Task<JobPost?> CreateJobPost(JobPost jobPost)
    {
        try
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("HttpClient is not initialized.");
            }

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

    public async Task<IEnumerable<JobPost>> ViewAllJobPosts()
    {
        try
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("HttpClient is not initialized.");
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/jobposts");
            return await ApiResponseHandler.HandleResponse<IEnumerable<JobPost>>(response) ?? [];
        }
        catch (HttpRequestException ex)
        {
            HandleException(ex);
            return [];
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return [];
        }
    }

    private static void HandleException(Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}