using Microsoft.EntityFrameworkCore;
using OcelotTemplate.Services.ProductManagement.EfCore.Entities;
using OcelotTemplate.Services.ProductManagement.EfCore.Mapping;

namespace OcelotTemplate.Services.ProductManagement.EfCore;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

       

        base.OnModelCreating(modelBuilder);
    }

}
