using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFNow.Data.Migrations
{
    public partial class FixTypoInPassingCompletionPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassintCompletionPercentage",
                table: "Players");

            migrationBuilder.AddColumn<float>(
                name: "PassingCompletionPercentage",
                table: "Players",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassingCompletionPercentage",
                table: "Players");

            migrationBuilder.AddColumn<float>(
                name: "PassintCompletionPercentage",
                table: "Players",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
