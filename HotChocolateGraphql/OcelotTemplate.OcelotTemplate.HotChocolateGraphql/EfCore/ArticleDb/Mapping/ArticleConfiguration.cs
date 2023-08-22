using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Mapping;

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
        
    }
}