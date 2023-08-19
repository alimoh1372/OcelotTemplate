using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcelotTemplate.Services.ArticleManagement.EfCore;
using OcelotTemplate.Services.ArticleManagement.EfCore.Entities;
using OcelotTemplate.Services.ArticleManagement.EfCore.Entities.Models.ViewModels;

namespace OcelotTemplate.Services.ArticleManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleDbContext _context;

        public ArticleController(ArticleDbContext context)
        {
            _context = context;
        }

        [HttpGet("Articles")]
        public async Task<IActionResult> Articles()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            var result = await _context.Articles.Include(x => x.ArticleCategory).ToListAsync();
            var json = JsonSerializer.Serialize(result, options);

            return Ok(json);
        }

        [HttpGet("Article")]

        public async Task<IActionResult> Article(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
                // دیگر تنظیمات
            };
            var result = await _context.Articles.Include(x => x.ArticleCategory).FirstOrDefaultAsync(x => x.Id == id);

            var json = JsonSerializer.Serialize(result, options);
            return Ok( json);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleCreateCommand command)
        {
            var _article = new Article()
            {
                Fk_ArticleCategoryId = command.FkArticleCategoryId,
                Name = command.Name,
                Description = command.Description
            };
            await _context.Articles.AddAsync(_article);
             await _context.SaveChangesAsync();
            return Ok($"Article with id={_article.Id} added successfully...");
        }


       
    }
}
