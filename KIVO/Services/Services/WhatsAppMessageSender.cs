namespace KIVO.Services.Services
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Azure.Messaging;
    using KIVO.Models.Dto;
    using KIVO.Services.IServerces;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Twilio.Jwt.AccessToken;

    public class WhatsAppMessageSender : IMessageSender
    {
        private readonly string accessToken;
        private readonly string phoneNumberId;
        private  readonly string ApiUrl;

        public WhatsAppMessageSender(ILogger<WhatsAppMessageSender> logger,IOptions<WhatsAppApiConfig> whatsAppApiConfig )
        {
            this.accessToken = whatsAppApiConfig.Value.Token; 
            this.phoneNumberId = whatsAppApiConfig.Value.PhoneNumerId;
            Logger = logger;
            ApiUrl = $"https://graph.facebook.com/v20.0/{phoneNumberId}/messages";
        }

        public ILogger<WhatsAppMessageSender> Logger { get; }

        public async Task<bool> SendMessageAsync(string recipientPhoneNumber, string verificationCode)
        {

          
            var messageContent = CreateWhatsAppMessage("verification_code", recipientPhoneNumber, verificationCode);
            using var client = new HttpClient();

            var content = new StringContent(messageContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            try
            {
                var response = await client.PostAsync(ApiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        private  string CreateWhatsAppMessage(string templateName, string recipientPhoneNumber, string conten)
        {
            var message = new
            {
                messaging_product = "whatsapp",
                to = recipientPhoneNumber,
                type = "template",
                template = new
                {
                    name = templateName,
                    language = new { code = "es" },
                    components = new object[]
                    {
                  new
                  {
                      type = "body",
                      parameters = new object[]
                      {
                          new { type = "text", text = conten }
                      }
                  },
                  new
                  {
                      type = "button",
                      sub_type = "url",
                      index = 0,
                      parameters = new object[]
                      {
                          new { type = "text", text = conten }
                      }
                  }
                    }
                }
            };

            return JsonConvert.SerializeObject(message);
        }

        // Método para enviar el mensaje usando HttpClient
    

    }

}
