using Microsoft.AspNetCore.Mvc;
using NewsHub.Data.Models;
using NewsHub.Data.Repository;
using NewsHub.Shared.DTOs;

namespace NewsHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> GetArticles()
        {
            var articles = await _articleRepository.GetAllAsync();
            var articleDtos = articles.Select(a => new ArticleDto
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                Source = a.Source,
                PublishedAt = a.PublisedDate
            }).ToList();

            return Ok(articleDtos);
        }

        [HttpPost] 
        public async Task<IActionResult> AddArticle(ArticleDto articleDto)
        {
            var article = new Article
            {
                Title = articleDto.Title,
                Content = articleDto.Content,
                Source = articleDto.Source,
                PublisedDate = articleDto.PublishedAt
            };

            await _articleRepository.AddAsync(article);
            return CreatedAtAction(nameof(GetArticles), new { id = article.Id }, articleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, ArticleDto articleDto)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null) return NotFound();

            article.Title = articleDto.Title;
            article.Content = articleDto.Content;
            article.Source = articleDto.Source;
            article.PublisedDate = articleDto.PublishedAt;

            await _articleRepository.UpdateAsync(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
