using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddBaladoLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoundcloudLink",
                table: "Balados",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Balados",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoundcloudLink",
                table: "Balados");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Balados");
        }
    }
}
