using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddOrderCategoryAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "BaladoCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ArticleCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "BaladoCategories");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ArticleCategories");
        }
    }
}
