namespace GithubFavoritesApi.Services.Interfaces;
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string body);
    }