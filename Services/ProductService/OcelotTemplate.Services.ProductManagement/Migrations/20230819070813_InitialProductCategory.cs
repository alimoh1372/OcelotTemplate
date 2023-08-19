using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcelotTemplate.Services.ProductManagement.Migrations
{
    public partial class InitialProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Fk_ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_Fk_ProductCategoryId",
                        column: x => x.Fk_ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "In this article just add about digital.", "Digital Products" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "In this article just add about digital.", "Public articles" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "In this article just add about Home facilities.", "Home product" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Fk_ProductCategoryId", "Name" },
                values: new object[] { 1, "A description about samsung a32", 1, "Sumsung a32 features" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Fk_ProductCategoryId", "Name" },
                values: new object[] { 2, "A description about persian carpet", 2, "Persian Carpet properties" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Fk_ProductCategoryId", "Name" },
                values: new object[] { 3, "A description about logitec keyboards", 1, "logitec Keyboards" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductCategoryId",
                table: "Products",
                column: "Fk_ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
