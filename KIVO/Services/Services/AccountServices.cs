using KIVO.Models.Dto;
using KIVO.Models;
using KIVO.Services.IServerces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity.UI.Services;

public class AccountServices
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly IConfiguration _configuration;
    private readonly IMessageSender _messageSender;
    private readonly SignInManager<User> _signInManager;

    public AccountServices(UserManager<User> userManager, IEmailSender emailSender, IConfiguration configuration, IMessageSender messageSender, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _emailSender = emailSender;
        _configuration = configuration;
        _messageSender = messageSender;
        _signInManager = signInManager;
    }

    public static string GenerateVerificationCode()
    {
        byte[] randomNumber = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        int result = BitConverter.ToInt32(randomNumber, 0) & 0xFFFFFF;
        return (result < 100000 ? result.ToString("D6") : result.ToString()).Substring(0, 6);
    }

    public async Task<OperationResult> Registrarse(InputModel model)
    {
        try
        {
            var verificationCode = GenerateVerificationCode();

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.CellPhone,
                VerificationCode = verificationCode,
                VerificationCodeExpiry = DateTime.UtcNow.AddMinutes(10)
            };

            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return OperationResult.Failure("El usuario ya existe con ese correo electrónico.");
            }

            // Si no existe, intenta crear el usuario
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return OperationResult.Failure("Error al crear el usuario. Por favor, intenta nuevamente.");
            }

            //var isValid = await _messageSender.SendMessageAsync(model.CellPhone, verificationCode);
            //if (!isValid)
            //{
            //    await _userManager.DeleteAsync(user);
            //    return OperationResult.Failure("Error al enviar el código de verificación. Por favor, intenta nuevamente.");
            //}

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var verificationLink = $"{_configuration["AppSettings:FrontendUrl"]}/verifyemail?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var subject = "Confirma tu correo electrónico";
            var body = $"Por favor, confirma tu cuenta haciendo clic en el siguiente enlace: <a href=\"{verificationLink}\">Confirmar Correo</a>";
            await _emailSender.SendEmailAsync(user.Email, subject, body);
            await _signInManager.SignInAsync(user, true);
            return OperationResult.Success("Usuario creado correctamente. Revisa tu correo y teléfono para la verificación.", user);
        }
        catch (Exception ex)
        {
            return OperationResult.Failure($"Ocurrió un error durante el registro: {ex.Message}");
        }
    }

    public async Task<OperationResult> HandleExternalLoginAsync(ExternalLoginInfo info)
    {
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        if (result.Succeeded)
        {
            var userResult = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            return OperationResult.Success("Inicio de sesión exitoso.", userResult);
        }

        var emailClaim = info.Principal.FindFirst(ClaimTypes.Email);
        if (emailClaim == null)
        {
            return OperationResult.Failure("No se pudo obtener el correo del proveedor externo.");
        }

        var email = emailClaim.Value;
        var user = new User
        {
            Email = email,
            UserName = email,
            VerificationCode = GenerateVerificationCode()
        };

        var identResult = await _userManager.CreateAsync(user);
        if (!identResult.Succeeded)
        {
            return OperationResult.Failure("Error al crear el usuario.");
        }

        identResult = await _userManager.AddLoginAsync(user, info);
        if (!identResult.Succeeded)
        {
            await _userManager.DeleteAsync(user);
            return OperationResult.Failure("Error al asociar el inicio de sesión externo.");
        }

        return OperationResult.Success("Usuario creado y asociado con éxito.", user);
    }

    public async Task<OperationResult> VerificarNumer(string userId, string verificationCode)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return OperationResult.Failure("El usuario no existe.");
        }

        if (user.VerificationCodeExpiry < DateTime.UtcNow)
        {
            return OperationResult.Failure("El código de verificación ha expirado.");
        }

        if (user.VerificationCode != verificationCode)
        {
            return OperationResult.Failure("Código no válido. Por favor, ingrese un código válido.");
        }

        user.PhoneNumberConfirmed = true;
        user.VerificationCode = null;
        user.VerificationCodeExpiry = null;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return OperationResult.Failure("Error al actualizar la información del usuario.");
        }

        return OperationResult.Success("Código verificado correctamente.", user);
    }
}
