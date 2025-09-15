using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UsersAPI.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Services
{
    public class EmailMessageService
    {
        private readonly MailJetSettings? _mailJetSettings;

        public EmailMessageService(IOptions<MailJetSettings?> mailJetSettings)
        {
            _mailJetSettings = mailJetSettings.Value;
        }

        public async Task SendEmailAsync(UserMessageVO userMessage)
        {
            var apiKey = _mailJetSettings.ApiKey;
            var secret = _mailJetSettings.SecretKey;
            var sender = _mailJetSettings.Sender;

            using var client = new HttpClient();

            // Basic auth: "APIKEY:SECRET"
            var basicToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{secret}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicToken);

            try
            {
                // Monta o payload
                var payload = new
                {
                    Messages = new[]
                    {
            new
            {
                From = new { Email = sender, Name ="API para controle de usuários - Curso C# Avançado Formação Arquiteto" },
                To   = new[] { new { Email = userMessage.To, Name = userMessage.To } },
                Subject = userMessage.Subject ?? "Sem assunto",
                TextPart = userMessage.Body ?? "",
                HTMLPart = $"<h3>{userMessage.Subject}</h3><p>{userMessage.Body}</p>"
            }
        }
                };

                var json = JsonConvert.SerializeObject(payload);
                Console.WriteLine("Outgoing JSON:\n" + json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.mailjet.com/v3.1/send", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("StatusCode: " + (int)response.StatusCode, "Email enviado com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Envio falhou: " + e.Message );
            }
        }
    }
}
