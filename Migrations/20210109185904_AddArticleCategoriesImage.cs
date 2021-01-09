using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddArticleCategoriesImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ArticleCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ImageId",
                table: "ArticleCategories",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Images_ImageId",
                table: "ArticleCategories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Images_ImageId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ImageId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ArticleCategories");
        }
    }
}
