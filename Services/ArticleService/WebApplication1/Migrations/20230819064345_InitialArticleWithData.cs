using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcelotTemplate.Services.ArticleManagement.Migrations
{
    public partial class InitialArticleWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Fk_ArticleCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_Fk_ArticleCategoryId",
                        column: x => x.Fk_ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "In this article just add about digital.", "Digital Articles" });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "In this article just add about digital.", "Public articles" });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "In this article just add about Home facilities.", "Home product" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Fk_ArticleCategoryId", "Name" },
                values: new object[] { 1, "A description about samsung a32", 1, "Sumsung a32 features" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Fk_ArticleCategoryId", "Name" },
                values: new object[] { 2, "A description about persian carpet", 2, "Persian Carpet properties" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Fk_ArticleCategoryId", "Name" },
                values: new object[] { 3, "A description about logitec keyboards", 1, "logitec Keyboards" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Fk_ArticleCategoryId",
                table: "Articles",
                column: "Fk_ArticleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategories");
        }
    }
}
