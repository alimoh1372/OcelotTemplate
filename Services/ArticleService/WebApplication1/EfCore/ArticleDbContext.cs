using Microsoft.EntityFrameworkCore;
using OcelotTemplate.Services.ArticleManagement.EfCore.Entities;
using OcelotTemplate.Services.ArticleManagement.EfCore.Mapping;

namespace OcelotTemplate.Services.ArticleManagement.EfCore;

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
