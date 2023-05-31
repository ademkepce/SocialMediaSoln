using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSoln.Persistence.Migrations
{
    public partial class File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImagUrl",
                table: "AppUsers",
                newName: "ProfileImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "AppUsers",
                newName: "ProfileImagUrl");
        }
    }
}
