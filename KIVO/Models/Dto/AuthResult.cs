using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models.Dto
{
  public class AuthResult
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public User User { get; private set; }
    public AuthErrorType ErrorType { get; private set; } // Nuevo tipo de error

    private AuthResult(bool isSuccess, string message, User user = null, AuthErrorType errorType = AuthErrorType.None)
    {
        IsSuccess = isSuccess;
        Message = message;
        User = user;
        ErrorType = errorType;
    }

    public static AuthResult Success(string message, User user = null)
    {
        return new AuthResult(true, message, user);
    }

    public static AuthResult Failure(string message, AuthErrorType errorType)
    {
        return new AuthResult(false, message, null, errorType);
    }
}

public enum AuthErrorType
{
    None,
    UserNotFound,
    PhoneNotConfirmed,
    EmailClaimNotFound,
    UserAlreadyExists,
    OperationFailed
}

}