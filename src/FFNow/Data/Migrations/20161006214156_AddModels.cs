using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FFNow.Data.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NflGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayScore = table.Column<string>(nullable: true),
                    AwayScoreOvertime = table.Column<string>(nullable: true),
                    AwayScoreQuarter1 = table.Column<string>(nullable: true),
                    AwayScoreQuarter2 = table.Column<string>(nullable: true),
                    AwayScoreQuarter3 = table.Column<string>(nullable: true),
                    AwayScoreQuarter4 = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    HomeScore = table.Column<string>(nullable: true),
                    HomeScoreOvertime = table.Column<string>(nullable: true),
                    HomeScoreQuarter1 = table.Column<string>(nullable: true),
                    HomeScoreQuarter2 = table.Column<string>(nullable: true),
                    HomeScoreQuarter3 = table.Column<string>(nullable: true),
                    HomeScoreQuarter4 = table.Column<string>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    StadiumName = table.Column<string>(nullable: true),
                    Week = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NflGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NflNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Opinion = table.Column<string>(nullable: true),
                    Team = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NflNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyPoints = table.Column<float>(nullable: false),
                    Fumbles = table.Column<float>(nullable: false),
                    FumblesLost = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PassingAttempts = table.Column<float>(nullable: false),
                    PassingCompletions = table.Column<float>(nullable: false),
                    PassingInterceptions = table.Column<float>(nullable: false),
                    PassingRating = table.Column<float>(nullable: false),
                    PassingTouchdowns = table.Column<float>(nullable: false),
                    PassingYards = table.Column<float>(nullable: false),
                    PassintCompletionPercentage = table.Column<float>(nullable: false),
                    Played = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    ReceivingTargets = table.Column<float>(nullable: false),
                    ReceivingTouchdowns = table.Column<float>(nullable: false),
                    ReceivingYards = table.Column<float>(nullable: false),
                    Receptions = table.Column<float>(nullable: false),
                    RecevingYardsPerReception = table.Column<float>(nullable: false),
                    RushingAttempts = table.Column<float>(nullable: false),
                    RushingTouchdowns = table.Column<float>(nullable: false),
                    RushingYards = table.Column<float>(nullable: false),
                    RushingYardsPerAttempt = table.Column<float>(nullable: false),
                    Started = table.Column<int>(nullable: false),
                    Team = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_PlayerId",
                table: "PlayersTeams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_TeamId",
                table: "PlayersTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NflGames");

            migrationBuilder.DropTable(
                name: "NflNews");

            migrationBuilder.DropTable(
                name: "PlayersTeams");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
