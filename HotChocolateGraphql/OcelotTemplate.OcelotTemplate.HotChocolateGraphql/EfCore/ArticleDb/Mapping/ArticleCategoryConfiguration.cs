﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Mapping;

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

    }
}