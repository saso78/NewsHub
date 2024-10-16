using NewsHub.Data.Models;
using NewsHub.Shared.DTOs;
using System.Net.Http.Json;

namespace NewsHub.Web.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch all articles from the API
        public async Task<List<ArticleDto>> GetArticlesAsync()
        {
            var articles = await _httpClient.GetFromJsonAsync<List<ArticleDto>>("api/articles");
            return articles ?? new List<ArticleDto>();
        }
    }
}

