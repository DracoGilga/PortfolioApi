using GithubFavoritesApi.Models;

namespace GithubFavoritesApi.Services.Interfaces;
public interface IGithubService
{
    Task<List<GithubRepository>> GetFavoriteRepositoriesAsync();
}