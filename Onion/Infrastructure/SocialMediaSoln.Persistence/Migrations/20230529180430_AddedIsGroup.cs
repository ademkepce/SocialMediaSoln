using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSoln.Persistence.Migrations
{
    public partial class AddedIsGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "AppUsers");
        }
    }
}
