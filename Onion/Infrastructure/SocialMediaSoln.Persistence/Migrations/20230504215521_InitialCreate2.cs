using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSoln.Persistence.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AppUsers_FollowerId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AppUsers_FollowingId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FollowingId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowerId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowingId",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Followers");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_AppUserId",
                table: "Followings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_AppUserId",
                table: "Followers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AppUsers_AppUserId",
                table: "Followers",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AppUsers_AppUserId",
                table: "Followings",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AppUsers_AppUserId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AppUsers_AppUserId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_AppUserId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followers_AppUserId",
                table: "Followers");

            migrationBuilder.AddColumn<int>(
                name: "FollowingId",
                table: "Followings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowerId",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowingId",
                table: "Followings",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerId",
                table: "Followers",
                column: "FollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AppUsers_FollowerId",
                table: "Followers",
                column: "FollowerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AppUsers_FollowingId",
                table: "Followings",
                column: "FollowingId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
