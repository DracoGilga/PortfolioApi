using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GithubFavoritesApi.Services.Interfaces;
using GithubFavoritesApi.Models;
using Microsoft.Extensions.Options;

namespace GithubFavoritesApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient(_settings.Host)
                {
                    Port = _settings.Port,
                    Credentials = new NetworkCredential(_settings.From, _settings.Password),
                    EnableSsl = _settings.EnableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_settings.From, _settings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(_settings.To);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error enviando correo: " + ex.Message);
                throw; // Esto se propaga hacia GraphQL y genera "Unexpected Execution Error"
            }
        }

    }
}