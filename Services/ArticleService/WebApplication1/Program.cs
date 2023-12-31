using OcelotTemplate.Services.ArticleManagement.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var env = builder.Environment.EnvironmentName;
builder.Services.AddControllers();

builder.Configuration.AddJsonFile($"appsettings.{env}.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.json", true, true);
builder.Services.AddArticleDependencies(builder.Configuration);
builder.Services.AddSwaggerGen();


var app = builder.Build();

// AddArticleDependencies the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Product API V1");
});
app.Run();
