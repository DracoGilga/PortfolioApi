using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using GithubFavoritesApi.Models;
using GithubFavoritesApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GithubFavoritesApi.Services;

public class GithubService : IGithubService
{
    private readonly HttpClient _httpClient;
    private readonly string _githubUsername;

    public GithubService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNet", "8"));

        _githubUsername = configuration["GitHub:Username"];
        var token = configuration["GitHub:Token"];

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<List<GithubRepository>> GetFavoriteRepositoriesAsync()
    {
        var reposUrl = $"https://api.github.com/users/{_githubUsername}/repos";
        var response = await _httpClient.GetAsync(reposUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var repoList = JsonSerializer.Deserialize<List<JsonElement>>(json);

        var favorites = repoList
            .Where(repo => repo.GetProperty("stargazers_count").GetInt32() > 0)
            .Select(async repo =>
            {
                var name = repo.GetProperty("name").GetString();
                var description = repo.TryGetProperty("description", out var descProp) ? descProp.GetString() : null;
                var updatedAt = repo.GetProperty("updated_at").GetDateTime();
                var htmlUrl = repo.GetProperty("html_url").GetString();

                var languagesResponse = await _httpClient.GetAsync($"https://api.github.com/repos/{_githubUsername}/{name}/languages");
                languagesResponse.EnsureSuccessStatusCode();
                var langJson = await languagesResponse.Content.ReadAsStringAsync();
                var langDict = JsonSerializer.Deserialize<Dictionary<string, long>>(langJson);

                var languages = langDict.Select(kvp => new LanguageUsage
                {
                    Name = kvp.Key,
                    Bytes = kvp.Value
                }).ToList();

                return new GithubRepository
                {
                    Name = name,
                    Description = description,
                    LastUpdated = updatedAt,
                    Url = htmlUrl,
                    Languages = languages
                };
            });

        return (await Task.WhenAll(favorites)).ToList();
    }
}