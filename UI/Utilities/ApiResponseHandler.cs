using System.Net.Http.Json;

namespace UI.Utilities;

public class ApiResponseHandler
{
    public static async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default;
            }

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content))
            {
                return default;
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new HttpRequestException("Resource not found.");
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new HttpRequestException("Unauthorized access.");
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException("Internal server error.");
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(errorMessage);
        }
        else
        {
            throw new HttpRequestException($"API request failed: {response.StatusCode}");
        }
    }

}