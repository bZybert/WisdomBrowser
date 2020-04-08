using Microsoft.EntityFrameworkCore.Migrations;

namespace WisdomBrowser.API.Migrations
{
    public partial class UpdateCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UsetId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UsetId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
