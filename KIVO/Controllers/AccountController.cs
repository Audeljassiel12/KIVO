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

        private readonly UserManager<User> _userManager;

        public Account(ILogger<Account> logger, UserManager<User> userManager, AccountServices accountServices, SignInManager<User> signInManager, IMessageSender messageSender)
        {


            _logger = logger;
            this.accountServices = accountServices;
            this.signInManager = signInManager;
            this.messageSender = messageSender;

            this._userManager = userManager;
        }

        public IActionResult Registrarse()
        {

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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(InputModelLogin Input)
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
                return RedirectToAction("Index", "Home");
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
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["ErrorMessage"] = "No se pudo obtener la información de inicio de sesión externo.";
                return RedirectToAction("Error");
            }

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user == null)
                {
                    return RedirectToAction(nameof(Login));
                }

                if (user.PhoneNumberConfirmed)
                {
                    string[] userInfo = {
                info.Principal.FindFirst(ClaimTypes.Name)?.Value,
                info.Principal.FindFirst(ClaimTypes.Email)?.Value
            };
                    return View(userInfo);
                }
                else
                {
                    TempData["Message"] = "Por favor verifica tu número de teléfono.";
                    return RedirectToAction(nameof(VerificarNumero));
                }
            }
            else
            {
                var emailClaim = info.Principal.FindFirst(ClaimTypes.Email);
                if (emailClaim == null)
                {
                    TempData["ErrorMessage"] = "No se pudo obtener el correo del proveedor externo.";
                    return RedirectToAction("Error");
                }

                var email = emailClaim.Value;
                var user = new User
                {
                    Email = email,
                    UserName = email,
                    VerificationCode = AccountServices.GenerateVerificationCode()
                };

                try
                {
                    var existingUser = await _userManager.FindByEmailAsync(user.Email);
                    if (existingUser != null)
                    {
                        TempData["ErrorMessage"] = "El usuario ya está registrado.";
                        return RedirectToAction("Error");
                    }

                    var identResult = await _userManager.CreateAsync(user);
                    if (!identResult.Succeeded)
                    {
                        TempData["ErrorMessage"] = string.Join(", ", identResult.Errors.Select(e => e.Description));
                        return RedirectToAction("Error");
                    }

                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (!identResult.Succeeded)
                    {
                        TempData["ErrorMessage"] = string.Join(", ", identResult.Errors.Select(e => e.Description));
                        return RedirectToAction("Error");
                    }

                    return RedirectToAction("VerificarNumero");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return RedirectToAction("Error");
                }
            }
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
            return RedirectToAction("Index", "Home");



        }
        public IActionResult RegistrarOrganizacion()
        {
            return View();
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
        public ActionResult CargarFormulario(string tipoOrganizacion)
        {
            if (tipoOrganizacion == "consultorio")
            {
                return PartialView("_FormularioConsultorio");
            }
            else if (tipoOrganizacion == "clinica")
            {
                return PartialView("_FormularioClinica");
            }

            return BadRequest();
        }

        public IActionResult Full()
        {
            return new JsonResult(new { nombre = "Hola" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}