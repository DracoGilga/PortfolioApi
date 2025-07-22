namespace GithubFavoritesApi.Models;
public class GithubRepository
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Url { get; set; }
    public List<LanguageUsage> Languages { get; set; }
}