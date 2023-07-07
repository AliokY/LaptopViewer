namespace LaptopViewer.Core.Models;

/// <summary>
/// Represents the response of an API call
/// </summary>
/// <typeparam name="T">The type of the response result</typeparam>
public class ApiResponse<T> where T : class
{
    public ApiResponse(T? result, string? error)
    {
        Error = error;
        Result = result;
    }
    public string? Error { get; init; }

    public T? Result { get; init; }

    public bool Success => string.IsNullOrEmpty(Error);
}
