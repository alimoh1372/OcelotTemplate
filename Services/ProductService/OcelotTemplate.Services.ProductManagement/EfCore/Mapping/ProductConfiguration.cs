using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.Services.ProductManagement.EfCore.Entities;

namespace OcelotTemplate.Services.ProductManagement.EfCore.Mapping;

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




        builder
            .HasData(new List<Product>
            {
                new Product(){Id=1,Fk_ProductCategoryId = 1,Name = "Sumsung a32 features",Description = "A description about samsung a32"},
                new Product(){Id=2,Fk_ProductCategoryId = 2,Name = "Persian Carpet properties",Description = "A description about persian carpet"},
                new Product(){Id=3,Fk_ProductCategoryId =1,Name = "logitec Keyboards",Description = "A description about logitec keyboards"},
            });

    }
}