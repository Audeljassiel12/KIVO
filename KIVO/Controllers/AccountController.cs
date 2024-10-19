using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using KIVO.Models;
using KIVO.Models.Dto;
using KIVO.Models.ViewModels;
using KIVO.Services.IServerces;
using KIVO.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KIVO.Controllers
{

    public class Account : Controller
    {
        private readonly ILogger<Account> _logger;
        private readonly AccountServices accountServices;
        private readonly SignInManager<User> signInManager;
        private readonly IMessageSender messageSender;
        private readonly IEmailSender emailSender;
        private readonly UserManager<User> _userManager;

        public Account(ILogger<Account> logger, UserManager<User> userManager, AccountServices accountServices, SignInManager<User> signInManager, IMessageSender messageSender,IEmailSender emailSender)
        {


            _logger = logger;
            this.accountServices = accountServices;
            this.signInManager = signInManager;
            this.messageSender = messageSender;
            this.emailSender = emailSender;
            this._userManager = userManager;
        }

        public IActionResult Registrarse()
        {
             if (User.Identity.IsAuthenticated)
    {
        // Redirigir a la página principal si el usuario ya está logueado
        return RedirectToAction("Index", "Home");
    }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(InputModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await accountServices.Registrarse(model);
                if (!result.IsSuccess)
                {
                    TempData["Error"] = result.Message;
                    return View(model);
                }


                return RedirectToAction("VerificarNumero");
            }


            return View();
        }
        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirigir a la página principal si el usuario ya está logueado
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(InputModelLogin Input, string returnUrl = null)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return View(Input);
            }

            // Intentar iniciar sesión con las credenciales proporcionadas
            var result = await signInManager.PasswordSignInAsync(
                Input.Email,
                Input.Password,
                Input.RememberMe,
                lockoutOnFailure: false);

            // Manejar el resultado del intento de inicio de sesión
            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario ha iniciado sesión correctamente.");
                // Redirigir al usuario a la página original o a la página por defecto
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl); // Redirige a la URL original
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Redirige a la página de inicio
                }
               
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa");
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("Cuenta de usuario bloqueada.");
                return RedirectToAction("Locked");
            }
            else
            {

                // Puedes usar TempData para mensajes adicionales si lo deseas
                TempData["ErrorMessage"] = "El nombre de usuario o la contraseña son incorrectos.";

                // Volver a mostrar la vista con el modelo para mantener los datos ingresados
                return View(Input);
            }
        }


        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {

            // Bloquear el acceso a usuarios ya autenticados
            if (User.Identity.IsAuthenticated)
            {
                // Redirigir a una página de inicio u otra acción si ya está autenticado
                return RedirectToAction("Index", "Home");
            }

            var authResult = await accountServices.HandleGoogleResponseAsync();

            if (!authResult.IsSuccess)
            {
                // Redirigir a la vista de verificación si el número no está confirmado
                if (authResult.ErrorType == AuthErrorType.PhoneNotConfirmed)
                {
                    return RedirectToAction("VerificarNumero");
                }

                TempData["ErrorMessage"] = authResult.Message;
                return RedirectToAction("Error");
            }


            return RedirectToAction("Index", "Pasiente");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> VerificarNumero()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Error");
            }

            // Verificar si el usuario inició sesión con Google
            var logins = await _userManager.GetLoginsAsync(user);
            var googleLogin = logins.FirstOrDefault(l => l.LoginProvider == "Google");

            var viewmodel = new VerifyIdentityViewModel
            {
                PhoneNumber = user.PhoneNumber,
                IsGoogleLogin = googleLogin != null // Esto indica si el usuario inició sesión con Google
            };

            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> VerificarNumeroPost(VerifyIdentityViewModel viewModel)
        {


            // Obtener el UserId desde la cookie de autenticación
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                // Si el usuario no está autenticado, redirigir al login o manejar el error
                return RedirectToAction("Login", "Account");
            }

            // Llamar al servicio para verificar el número de teléfono
            var result = await accountServices.VerificarNumer(userId, viewModel.VerificationCode);

            // Verificar si la verificación fue exitosa
            if (!result.IsSuccess)
            {
                // Si hay un error, mostrar el mensaje en la misma vista
                TempData["Error"] = result.Message;
                return RedirectToAction(nameof(VerificarNumero));
            }

            // Si la verificación es exitosa, redirigir al home o donde sea necesario
            return RedirectToAction("step-one","Configuracion") ;



        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendVerificationCode([FromBody] PhoneNumberModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado." });
            }

            // Verificar si el número de teléfono es diferente
            if (user.PhoneNumber != model.PhoneNumber)
            {
                // Actualizar el número de teléfono del usuario
                user.PhoneNumber = model.PhoneNumber;


            }
            user.VerificationCode = AccountServices.GenerateVerificationCode();
            user.VerificationCodeExpiry = DateTime.UtcNow.AddMinutes(10);
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return Json(new { success = false, message = "No se pudo actualizar el número de teléfono." });
            }

            // Intentar enviar el código de verificación
            try
            {
                var result = await messageSender.SendMessageAsync(model.PhoneNumber, user.VerificationCode);
                if (result)
                {
                    // Retornar una respuesta de éxito
                    return Json(new { success = true, message = "Código reenviado Correctamente" });
                }
                else
                {
                    // Retornar error si no se pudo enviar el código
                    return Json(new { success = false, message = "No se pudo enviar el código de verificación." });
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return Json(new { success = false, message = $"Error al enviar el código de verificación: {ex.Message}" });
            }


        }





        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user is null)
                {
                    return View("Error");
                }

                // Generar el token de restablecimiento de contraseña
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account",
       new { userId = user.Id, token = token }, protocol: Request.Scheme);

                // Enviar el correo con el enlace para restablecer la contraseña
                await emailSender.SendEmailAsync(model.Email, "Restablecer contraseña",
                    $"Por favor restablezca su contraseña haciendo <a href='{callbackUrl}'>clic aquí</a>.");

                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        // Acción de confirmación después de enviar el correo de restablecimiento
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // Acción para mostrar el formulario de restablecimiento de contraseña
        [HttpGet]
        public IActionResult ResetPassword(string token = null)
        {
            if (token == null)
            {
                return BadRequest("El token es inválido.");
            }
            var model = new ResetPasswordViewModel { Token = token };
            return View(model);
        }

        // Acción para procesar el restablecimiento de la contraseña
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // No revelar si el usuario no existe
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        // Confirmación después de restablecer la contraseña
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Activate2FA(bool twoFactor)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return View("Error");
            var user = await _userManager.FindByIdAsync(userId);

            user.TwoFactorEnabled = twoFactor;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Paciente", "Index");
            }

            return View("Error");
        }
        [HttpGet]
        public async Task< IActionResult>  Activate2FA()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return View("Error");
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }


        public IActionResult Error()
        {
           
            return View();
        }
    }
}