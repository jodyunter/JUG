using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameNo = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    HomeId = table.Column<long>(nullable: true),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayId = table.Column<long>(nullable: true),
                    AwayScore = table.Column<int>(nullable: false),
                    IsStarted = table.Column<bool>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    CanTie = table.Column<bool>(nullable: false),
                    NormalPeriods = table.Column<int>(nullable: false),
                    MaxOverTimePeriods = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayId",
                        column: x => x.AwayId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayId",
                table: "Games",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeId",
                table: "Games",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
