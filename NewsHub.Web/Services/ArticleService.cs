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
        public async Task<List<ArticleDto>> GetArticlesAsync()
        {
            var articles = await _httpClient.GetFromJsonAsync<List<ArticleDto>>("api/articles");
            return articles ?? new List<ArticleDto>();
        }
        public async Task AddArticleAsync(ArticleDto article) =>
        await _httpClient.PostAsJsonAsync("api/articles", article);

        public async Task UpdateArticleAsync(int id, ArticleDto article) =>
            await _httpClient.PutAsJsonAsync($"api/articles/{id}", article);

        public async Task DeleteArticleAsync(int id) =>
            await _httpClient.DeleteAsync($"api/articles/{id}");
    }
}

