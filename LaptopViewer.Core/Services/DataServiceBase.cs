using LaptopViewer.Core.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace LaptopViewer.Core.Services;

public abstract class DataServiceBase
{
    /// <summary>
    /// Sends an HTTP GET request to the specified URI and retrieves the response content
    /// </summary>
    /// <typeparam name="T">The type of the response content</typeparam>
    /// <param name="uri">The URI to send the request to</param>
    /// <param name="cancellationToken">The cancellation token to cancel the request</param>
    /// <returns>An ApiResponse object containing the response content or an error message</returns>
    protected async Task<ApiResponse<T>> GetAsync<T>(Uri uri, CancellationToken cancellationToken) where T : class
    {
        using var client = new HttpClient() { BaseAddress= uri };

        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync(cancellationToken);

            return new ApiResponse<T>(Parse<T>(content), null);
        }
        catch (Exception ex)
        {
            return new ApiResponse<T>(null, $"Loading data failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Parses the JSON content into the specified type
    /// </summary>
    /// <typeparam name="T">The type to parse the content into</typeparam>
    /// <param name="content">The JSON content to parse</param>
    /// <returns>The parsed object of the specified type</returns>
    private static T? Parse<T>(string content) where T : class
    {
        if (string.IsNullOrWhiteSpace(content)) 
            throw new ArgumentException("Content is empty", nameof(content));

        return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings() { });
    }
}
