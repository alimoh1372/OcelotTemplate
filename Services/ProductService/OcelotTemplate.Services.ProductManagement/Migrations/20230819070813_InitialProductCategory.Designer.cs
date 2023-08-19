﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OcelotTemplate.Services.ProductManagement.EfCore;

#nullable disable

namespace OcelotTemplate.Services.ProductManagement.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230819070813_InitialProductCategory")]
    partial class InitialProductCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OcelotTemplate.Services.ProductManagement.EfCore.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Fk_ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_ProductCategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A description about samsung a32",
                            Fk_ProductCategoryId = 1,
                            Name = "Sumsung a32 features"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A description about persian carpet",
                            Fk_ProductCategoryId = 2,
                            Name = "Persian Carpet properties"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A description about logitec keyboards",
                            Fk_ProductCategoryId = 1,
                            Name = "logitec Keyboards"
                        });
                });

            modelBuilder.Entity("OcelotTemplate.Services.ProductManagement.EfCore.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "In this article just add about digital.",
                            Title = "Digital Products"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In this article just add about digital.",
                            Title = "Public articles"
                        },
                        new
                        {
                            Id = 3,
                            Description = "In this article just add about Home facilities.",
                            Title = "Home product"
                        });
                });

            modelBuilder.Entity("OcelotTemplate.Services.ProductManagement.EfCore.Entities.Product", b =>
                {
                    b.HasOne("OcelotTemplate.Services.ProductManagement.EfCore.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("Fk_ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("OcelotTemplate.Services.ProductManagement.EfCore.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
