public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }

    public ApiResponse() { }

    public ApiResponse(bool success, T? data = default, string? message = null, string? error = null)
    {
        Success = success;
        Data = data;
        Message = message;
        Error = error;
    }

    public static ApiResponse<T> SuccessResponse(T data, string? message = null)
    {
        return new ApiResponse<T>(true, data, message, null);
    }

    public static ApiResponse<T> ErrorResponse(string error, string? message = null)
    {
        return new ApiResponse<T>(false, default, message, error);
    }
}
