using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class GameStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayShots",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeShots",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayShots",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeShots",
                table: "Games");
        }
    }
}
