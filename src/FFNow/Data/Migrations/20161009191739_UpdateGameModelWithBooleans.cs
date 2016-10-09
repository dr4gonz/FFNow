using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFNow.Data.Migrations
{
    public partial class UpdateGameModelWithBooleans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "NflGames",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOver",
                table: "NflGames",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "QuarterDescription",
                table: "NflGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "NflGames");

            migrationBuilder.DropColumn(
                name: "IsOver",
                table: "NflGames");

            migrationBuilder.DropColumn(
                name: "QuarterDescription",
                table: "NflGames");
        }
    }
}
