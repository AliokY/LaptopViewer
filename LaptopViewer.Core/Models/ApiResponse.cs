namespace LaptopViewer.Core.Models;

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
