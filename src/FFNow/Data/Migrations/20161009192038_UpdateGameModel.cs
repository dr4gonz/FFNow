using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFNow.Data.Migrations
{
    public partial class UpdateGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quarter",
                table: "NflGames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeRemaining",
                table: "NflGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quarter",
                table: "NflGames");

            migrationBuilder.DropColumn(
                name: "TimeRemaining",
                table: "NflGames");
        }
    }
}
