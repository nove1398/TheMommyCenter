using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MommyDayCare.Server.Migrations
{
    public partial class appuserGroupEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserGroupId",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn", "UserSlug" },
                values: new object[] { new DateTime(2020, 6, 5, 7, 7, 3, 356, DateTimeKind.Local).AddTicks(4039), new DateTime(2020, 5, 5, 7, 7, 3, 355, DateTimeKind.Local).AddTicks(1830), new Guid("c12327bc-bbcf-4edc-ab5a-43498a5cfa93") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserGroupId",
                table: "AppUsers",
                column: "AppUserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUserGroups_AppUserGroupId",
                table: "AppUsers",
                column: "AppUserGroupId",
                principalTable: "AppUserGroups",
                principalColumn: "AppUserGroupId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserGroups_AppUserGroupId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppUserGroupId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppUserGroupId",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn", "UserSlug" },
                values: new object[] { new DateTime(2020, 6, 5, 6, 4, 52, 49, DateTimeKind.Local).AddTicks(8449), new DateTime(2020, 5, 5, 6, 4, 52, 48, DateTimeKind.Local).AddTicks(6267), new Guid("6a745453-4812-4de0-b063-8b2f75f4f0a6") });
        }
    }
}
