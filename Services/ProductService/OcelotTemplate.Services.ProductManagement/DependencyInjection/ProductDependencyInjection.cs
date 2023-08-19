using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcelotTemplate.Services.ProductManagement.EfCore;

namespace OcelotTemplate.Services.ProductManagement.DependencyInjection;

public static class ProductDependencyInjection
{
    
    public static IServiceCollection AddProductDependencies(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString=  configuration.GetConnectionString("ProductConnectionString");
        services.AddDbContext<ProductDbContext>(
                opt=>opt.UseSqlServer(connectionString)
                );
            
        return services;
    }
}