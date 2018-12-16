using Microsoft.EntityFrameworkCore.Migrations;

namespace CCPhus.API.Migrations
{
    public partial class RemoveOwnerFromScriptModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Users_UserId",
                table: "Scripts");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Scripts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Scripts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Scripts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Users_UserId",
                table: "Scripts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Users_UserId",
                table: "Scripts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Scripts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Scripts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Users_UserId",
                table: "Scripts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
