using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Mapping;

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
    }
}