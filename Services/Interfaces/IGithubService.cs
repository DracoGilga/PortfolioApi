using System.Collections.Generic;
using System.Threading.Tasks;
using GithubFavoritesApi.Models;

namespace GithubFavoritesApi.Services.Interfaces;
public interface IGithubService
{
    Task<List<GithubRepository>> GetFavoriteRepositoriesAsync();
}