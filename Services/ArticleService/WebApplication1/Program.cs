using OcelotTemplate.Services.ArticleManagement.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddJsonFile()
builder.Services.AddArticleDependencies();


var app = builder.Build();

// AddArticleDependencies the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
