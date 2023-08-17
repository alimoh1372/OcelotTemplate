using Microsoft.EntityFrameworkCore;
using OcelotTemplate.Services.ArticleManagement.EfCore;

namespace OcelotTemplate.Services.ArticleManagement.DependencyInjection;

public static class ArticleDependencyInjection
{
    public static IServiceCollection AddArticleDependencies(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString=  configuration.GetConnectionString("ArticleConnectionString");
        services.AddDbContext<ArticleDbContext>(
                opt=>opt.UseSqlServer(connectionString)
                );
            
        return services;
    }
}