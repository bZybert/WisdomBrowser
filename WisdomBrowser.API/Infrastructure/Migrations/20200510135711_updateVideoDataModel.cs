using Microsoft.EntityFrameworkCore.Migrations;

namespace WisdomBrowser.API.Infrastructure.Migrations
{
    public partial class updateVideoDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Videos");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UserId",
                table: "Videos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_UserId",
                table: "Videos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_UserId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_UserId",
                table: "Videos");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Videos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
