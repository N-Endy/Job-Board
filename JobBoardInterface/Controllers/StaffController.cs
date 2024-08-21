using System.Net.Http.Json;
using JobBoardInterface.Models;
using JobBoardInterface.Utilities;

namespace JobBoardInterface.Controllers;
public class StaffController
{
    private readonly HttpClient? _httpClient = new();
    private readonly string? _baseUrl = "https://localhost:7107";

    public async Task<Staff?> Add(Staff staff)
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

    public async Task<Staff?> GetStaffLogin(string username)
    {
        try
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("HttpClient is not initialized.");
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/staffs/find/{username}");
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

    public async Task<Staff?> GetStaff()
    {
        try
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("HttpClient is not initialized.");
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/staffs");
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

    private static void HandleException(Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
