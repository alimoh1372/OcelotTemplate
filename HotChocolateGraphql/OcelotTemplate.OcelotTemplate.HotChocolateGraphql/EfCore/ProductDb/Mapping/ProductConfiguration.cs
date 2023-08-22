using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Mapping;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.ToTable("Products");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
        builder.Property(a => a.Description).HasColumnType("nvarchar").HasMaxLength(2000);

        builder.HasOne(x => x.ProductCategory)  
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.Fk_ProductCategoryId);

    }
}