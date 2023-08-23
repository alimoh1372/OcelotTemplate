using Microsoft.EntityFrameworkCore;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductAgg;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductCategoryAgg;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProductConnectionString");


        services.AddPooledDbContextFactory<ProductDbContext>(
            opt => opt.UseSqlServer(connectionString)
        );
        //services.AddDbContext<ArticleDbContext>(opt =>
        //{
        //    opt.UseSqlServer(connectionString);
        //});

        services.AddGraphQL()
            .AddGraphQLServer()
            .RegisterDbContext<ProductDbContext>(DbContextKind.Pooled)
            // .AddProjections()  //Using this when want to load the children data
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<ProductType>()
            .AddType<ProductCategoryType>()
            .AddSorting()
            .AddFiltering();
        return services;
    }
}