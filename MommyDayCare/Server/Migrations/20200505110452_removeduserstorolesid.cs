using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MommyDayCare.Server.Migrations
{
    public partial class removeduserstorolesid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersToRolesId",
                table: "UsersToRoles");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "Birthday", "Email", "RegisteredOn", "UserSlug" },
                values: new object[] { new DateTime(2020, 6, 5, 6, 4, 52, 49, DateTimeKind.Local).AddTicks(8449), "test@gmail.com", new DateTime(2020, 5, 5, 6, 4, 52, 48, DateTimeKind.Local).AddTicks(6267), new Guid("6a745453-4812-4de0-b063-8b2f75f4f0a6") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersToRolesId",
                table: "UsersToRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "Birthday", "Email", "RegisteredOn", "UserSlug" },
                values: new object[] { new DateTime(2020, 6, 2, 7, 15, 27, 507, DateTimeKind.Local).AddTicks(3361), "testc@gmail.com", new DateTime(2020, 5, 2, 7, 15, 27, 505, DateTimeKind.Local).AddTicks(9309), new Guid("3df6c47a-9446-40a9-a8d1-6c4321ae1e8c") });

            migrationBuilder.UpdateData(
                table: "UsersToRoles",
                keyColumns: new[] { "AppUserId", "AppUserRoleId" },
                keyValues: new object[] { 1, 1 },
                column: "UsersToRolesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UsersToRoles",
                keyColumns: new[] { "AppUserId", "AppUserRoleId" },
                keyValues: new object[] { 1, 2 },
                column: "UsersToRolesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "UsersToRoles",
                keyColumns: new[] { "AppUserId", "AppUserRoleId" },
                keyValues: new object[] { 1, 3 },
                column: "UsersToRolesId",
                value: 3);
        }
    }
}
