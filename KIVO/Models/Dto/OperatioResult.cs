using KIVO.Models;

public class OperationResult
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public User User { get; private set; }

    private OperationResult(bool isSuccess, string message, User user = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        User = user;
    }

    public static OperationResult Success(string message, User user = null)
    {
        return new OperationResult(true, message, user);
    }

    public static OperationResult Failure(string message)
    {
        return new OperationResult(false, message);
    }
}
