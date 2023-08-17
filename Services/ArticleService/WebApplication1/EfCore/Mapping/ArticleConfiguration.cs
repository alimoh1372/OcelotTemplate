using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.Services.ArticleManagement.EfCore.Entities;

namespace OcelotTemplate.Services.ArticleManagement.EfCore.Mapping;

public class ArticleConfiguration:IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {

        builder.ToTable("Articles");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
        builder.Property(a => a.Description).HasColumnType("nvarchar").HasMaxLength(2000);

        builder.HasOne(x => x.ArticleCategory)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.Fk_ArticleCategoryId);




        builder
            .HasData(new List<Article>
            {
                new Article(){Fk_ArticleCategoryId = 1,Name = "Sumsung a32 features",Description = "A description about samsung a32"},
                new Article(){Fk_ArticleCategoryId = 2,Name = "Persian Carpet properties",Description = "A description about persian carpet"},
                new Article(){Fk_ArticleCategoryId =1,Name = "logitec Keyboards",Description = "A description about logitec keyboards"},
            });

    }
}