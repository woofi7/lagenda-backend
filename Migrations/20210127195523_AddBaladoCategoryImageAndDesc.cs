using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddBaladoCategoryImageAndDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "BaladoCategories",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "BaladoCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaladoCategories_ImageId",
                table: "BaladoCategories",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaladoCategories_Images_ImageId",
                table: "BaladoCategories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaladoCategories_Images_ImageId",
                table: "BaladoCategories");

            migrationBuilder.DropIndex(
                name: "IX_BaladoCategories_ImageId",
                table: "BaladoCategories");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "BaladoCategories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "BaladoCategories");
        }
    }
}
