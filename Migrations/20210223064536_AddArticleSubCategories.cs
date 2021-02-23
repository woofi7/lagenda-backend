using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddArticleSubCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleAuthorCategoryId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleAuthorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Unlisted = table.Column<bool>(type: "bit(1)", nullable: false),
                    ExternalLink = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ArticleCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAuthorCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleAuthorCategories_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleAuthorCategories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleAuthorCategoryId",
                table: "Articles",
                column: "ArticleAuthorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthorCategories_ArticleCategoryId",
                table: "ArticleAuthorCategories",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthorCategories_ImageId",
                table: "ArticleAuthorCategories",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleAuthorCategories_ArticleAuthorCategoryId",
                table: "Articles",
                column: "ArticleAuthorCategoryId",
                principalTable: "ArticleAuthorCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleAuthorCategories_ArticleAuthorCategoryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleAuthorCategories");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleAuthorCategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleAuthorCategoryId",
                table: "Articles");
        }
    }
}
