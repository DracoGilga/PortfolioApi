/*using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubFavoritesApi.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HealthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("live")]
        public IActionResult Live() => Ok("API is running");

        [HttpGet("ready")]
        public async Task<IActionResult> Ready()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("DotNet");

            var githubStatus = await client.GetAsync("https://api.github.com");

            if (githubStatus.IsSuccessStatusCode)
                return Ok("GitHub API reachable");
            else
                return StatusCode(503, "GitHub API not reachable");
        }
    }
*/