using Microsoft.EntityFrameworkCore.Migrations;

namespace LagendaBackend.Migrations
{
    public partial class AddProfileRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Profiles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "anonymous");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Profiles");
        }
    }
}
