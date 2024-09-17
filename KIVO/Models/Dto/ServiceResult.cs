public class ServiceResult<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public T Data { get; set; }

    public static ServiceResult<T> SuccessResult(T data, string message = "", int statusCode = 200)
    {
        return new ServiceResult<T> { Success = true, Message = message, StatusCode = statusCode, Data = data };
    }

    public static ServiceResult<T> SuccessResult(string message = "", int statusCode = 200)
    {
        return new ServiceResult<T> { Success = true, Message = message, StatusCode = statusCode, Data = default };
    }

    public static ServiceResult<T> ErrorResult(string message, int statusCode = 500)
    {
        return new ServiceResult<T> { Success = false, Message = message, StatusCode = statusCode, Data = default };
    }
}
