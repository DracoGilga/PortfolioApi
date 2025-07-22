using System.Collections.Generic;
using System.Threading.Tasks;
using GithubFavoritesApi.Models;
using GithubFavoritesApi.Services.Interfaces;

namespace GithubFavoritesApi.GraphQL;

public class PdfResult
{
    public string FileName { get; set; }
    public string Base64 { get; set; }
}

public class GithubQuery
{
    public async Task<List<GithubRepository>> GetRepositoriesAsync(
        [Service] IGithubService githubService) =>
        await githubService.GetFavoriteRepositoriesAsync();

    public PdfResult GetPdfAsBase64()
    {
        var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "PrivateFiles", "Cesar-Gonzalez-Lopez_CV.pdf");

        if (!System.IO.File.Exists(path))
            return null;

        var bytes = System.IO.File.ReadAllBytes(path);
        return new PdfResult
        {
            FileName = "Cesar-Gonzalez-Lopez_CV.pdf",
            Base64 = Convert.ToBase64String(bytes)
        };
    }
}