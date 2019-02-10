using Microsoft.EntityFrameworkCore.Migrations;

namespace CCPhus.API.Migrations
{
    public partial class AddPublicIdToAvatarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Avatars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Avatars");
        }
    }
}
