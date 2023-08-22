using Microsoft.EntityFrameworkCore;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Entities;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Mapping;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb;

public class ArticleDbContext : DbContext
{
    public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
    {

    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleCategory> ArticleCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleConfiguration).Assembly);

       

        base.OnModelCreating(modelBuilder);
    }

}
