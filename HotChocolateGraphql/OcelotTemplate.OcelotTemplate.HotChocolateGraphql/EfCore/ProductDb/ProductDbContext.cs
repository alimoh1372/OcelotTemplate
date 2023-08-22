using Microsoft.EntityFrameworkCore;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Mapping;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleCategoryConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
