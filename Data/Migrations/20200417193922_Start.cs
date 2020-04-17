using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    TeamType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    CompetitionId = table.Column<long>(nullable: true),
                    RegulationWins = table.Column<int>(nullable: true),
                    OverTimeWins = table.Column<int>(nullable: true),
                    RegulationLoses = table.Column<int>(nullable: true),
                    OverTimeLoses = table.Column<int>(nullable: true),
                    Ties = table.Column<int>(nullable: true),
                    GoalsFor = table.Column<int>(nullable: true),
                    GoalsAgainst = table.Column<int>(nullable: true),
                    ShotsFor = table.Column<int>(nullable: true),
                    ShotsAgainst = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    HomeShots = table.Column<int>(nullable: false),
                    AwayId = table.Column<long>(nullable: true),
                    AwayScore = table.Column<int>(nullable: false),
                    AwayShots = table.Column<int>(nullable: false),
                    IsStarted = table.Column<bool>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    CanTie = table.Column<bool>(nullable: false),
                    NormalPeriods = table.Column<int>(nullable: false),
                    MaxOverTimePeriods = table.Column<int>(nullable: false),
                    CompetitionId = table.Column<long>(nullable: true)
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
                        name: "FK_Games_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
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
                name: "IX_Games_CompetitionId",
                table: "Games",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeId",
                table: "Games",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CompetitionId",
                table: "Teams",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ParentId",
                table: "Teams",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
