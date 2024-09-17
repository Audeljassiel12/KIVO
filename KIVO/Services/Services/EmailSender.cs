namespace KIVO.Services.Services
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using KIVO.Models.Dto;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Options;

    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var fromAddress = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName);
            var toAddress = new MailAddress(email);

            using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
            {
                client.EnableSsl = true; // Asegúrate de habilitar SSL/TLS
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);

                // Configura el mensaje de correo
                var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                try
                {
                    // Envía el correo electrónico de forma asíncrona
                    await client.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                { 
                   Console.Write(ex.ToString());
                }
                
            }

        }
    }
}
