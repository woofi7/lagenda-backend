using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddSimpleCastId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SimpleCastId",
                table: "Balados",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SimpleCastId",
                table: "Balados");
        }
    }
}
