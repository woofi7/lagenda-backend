using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddBaladoPartners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaladoPartnerId",
                table: "BaladoCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
	            name: "Unlisted",
	            table: "BaladoCategories",
	            nullable: false,
	            defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BaladoPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Desc = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Unlisted = table.Column<bool>(nullable: false, defaultValue: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaladoPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaladoPartners_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaladoCategories_BaladoPartnerId",
                table: "BaladoCategories",
                column: "BaladoPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BaladoPartners_ImageId",
                table: "BaladoPartners",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaladoCategories_BaladoPartners_BaladoPartnerId",
                table: "BaladoCategories",
                column: "BaladoPartnerId",
                principalTable: "BaladoPartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaladoCategories_BaladoPartners_BaladoPartnerId",
                table: "BaladoCategories");

            migrationBuilder.DropTable(
                name: "BaladoPartners");

            migrationBuilder.DropIndex(
                name: "IX_BaladoCategories_BaladoPartnerId",
                table: "BaladoCategories");

            migrationBuilder.DropColumn(
                name: "BaladoPartnerId",
                table: "BaladoCategories");

            migrationBuilder.DropColumn(
                name: "Unlisted",
                table: "BaladoCategories");
        }
    }
}
