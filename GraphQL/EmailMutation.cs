using GithubFavoritesApi.Models;
using GithubFavoritesApi.Services.Interfaces;
using System.Threading.Tasks;

namespace GithubFavoritesApi.GraphQL
{
    public class EmailMutation
    {
        public async Task<bool> SendContactEmail(
            ContactMail input,
            [Service] IEmailService emailService)
        {
            var subject = "Nuevo mensaje desde el portafolio de DracoGilga";
            var body = $@"
                Hola Cesar,

                La persona {input.FirstName} {input.LastName}
                con correo: {input.Email}
                te ha mandado este mensaje para contactarte:

                {input.Message}

                Atte.
                Portafolio de DracoGilga
            ";

            await emailService.SendEmailAsync(subject, body);
            return true;
        }
    }
}