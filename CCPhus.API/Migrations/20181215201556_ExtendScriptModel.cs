using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCPhus.API.Migrations
{
    public partial class ExtendScriptModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastRun",
                table: "Scripts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRun",
                table: "Scripts");
        }
    }
}
