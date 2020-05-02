using Microsoft.EntityFrameworkCore.Migrations;

namespace MommyDayCare.Server.Migrations
{
    public partial class RolesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "AppUserRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "AppUserRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
