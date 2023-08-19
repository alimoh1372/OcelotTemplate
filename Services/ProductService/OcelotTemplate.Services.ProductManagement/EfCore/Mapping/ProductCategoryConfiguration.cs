using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.Services.ProductManagement.EfCore.Entities;

namespace OcelotTemplate.Services.ProductManagement.EfCore.Mapping;

public class ProductCategoryConfiguration:IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
        builder.Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(2000);


        builder.HasMany(x => x.Products)            
            .WithOne(x => x.ProductCategory)
            .HasForeignKey(x => x.Fk_ProductCategoryId);


        var _productCategories = new ProductCategory[]
        {
            new ProductCategory {Id=1, Title = "Digital Products", Description = "In this article just add about digital." },
            new ProductCategory {Id=2, Title = "Public articles", Description = "In this article just add about digital." },
            new ProductCategory {Id=3, Title = "Home product", Description = "In this article just add about Home facilities." }
        };
        builder
            .HasData(_productCategories);
    }
}