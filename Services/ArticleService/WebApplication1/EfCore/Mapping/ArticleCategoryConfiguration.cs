using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.Services.ArticleManagement.EfCore.Entities;

namespace OcelotTemplate.Services.ArticleManagement.EfCore.Mapping;

public class ArticleCategoryConfiguration:IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder.ToTable("ArticleCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
        builder.Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(2000);


        builder.HasMany(x => x.Articles)
            .WithOne(x => x.ArticleCategory)
            .HasForeignKey(x => x.Fk_ArticleCategoryId);


        var _articleCategories = new ArticleCategory[]
        {
            new ArticleCategory { Title = "Digital Articles", Description = "In this article just add about digital." },
            new ArticleCategory { Title = "Public articles", Description = "In this article just add about digital." },
            new ArticleCategory { Title = "Home product", Description = "In this article just add about Home facilities." }
        };
        builder
            .HasData(_articleCategories);
    }
}