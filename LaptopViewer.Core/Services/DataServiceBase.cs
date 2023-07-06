using LaptopViewer.Core.Models;
using Newtonsoft.Json;

namespace LaptopViewer.Core.Services;

public abstract class DataServiceBase
{
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
    
    private T? Parse<T>(string content) where T : class
    {
        if (string.IsNullOrWhiteSpace(content)) 
            throw new ArgumentException("Content is empty", nameof(content));

        return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings() { });
    }
}
