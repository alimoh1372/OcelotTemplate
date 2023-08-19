using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcelotTemplate.Services.ProductManagement.EfCore;
using OcelotTemplate.Services.ProductManagement.EfCore.Entities;
using OcelotTemplate.Services.ProductManagement.EfCore.Entities.Models.Dtos;

namespace OcelotTemplate.Services.ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> Products()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            var result = await _context.Products.ToListAsync();
            var json = JsonSerializer.Serialize(result, options);

            return Ok(json);
        }

        [HttpGet("Product")]

        public async Task<IActionResult> Product(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
                // دیگر تنظیمات
            };
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            var json = JsonSerializer.Serialize(result, options);
            return Ok( json);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateCommand command)
        {
            var _article = new Product()
            {
                Fk_ProductCategoryId = command.FkProductCategoryId,
                Name = command.Name,
                Description = command.Description
            };
            await _context.Products.AddAsync(_article);
             await _context.SaveChangesAsync();
            return Ok($"Product with id={_article.Id} added successfully...");
        }
    }
}
