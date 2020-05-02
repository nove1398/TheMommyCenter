using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MommyDayCare.Server.Migrations
{
    public partial class RolesAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AppUserRoles");

            migrationBuilder.CreateTable(
                name: "UsersToRoles",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false),
                    AppUserRoleId = table.Column<int>(nullable: false),
                    UsersToRolesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToRoles", x => new { x.AppUserId, x.AppUserRoleId });
                    table.ForeignKey(
                        name: "FK_UsersToRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToRoles_AppUserRoles_AppUserRoleId",
                        column: x => x.AppUserRoleId,
                        principalTable: "AppUserRoles",
                        principalColumn: "AppUserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Access to site content", "User" },
                    { 1, "Access to all the site content", "Administrator" },
                    { 2, "Access to approve some site content", "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "ActivationKey", "Avatar", "Biography", "Birthday", "Country", "Email", "FirstName", "IsActive", "IsPrivate", "LastLogin", "LastName", "LoginAttemps", "Password", "RegisteredOn", "Salt", "Sex", "UpdatedOn", "UserSlug", "Username" },
                values: new object[] { 1, 0, "", "Hi, I am me", new DateTime(2020, 6, 2, 7, 15, 27, 507, DateTimeKind.Local).AddTicks(3361), "jamaica", "testc@gmail.com", "nove", true, false, null, "francis", 0, "254954d957f71e705815ed79dd9481d68b5f3cf4b5933fb1516929886c0bb221", new DateTime(2020, 5, 2, 7, 15, 27, 505, DateTimeKind.Local).AddTicks(9309), "Irk/0AuJPJABaDmJ5z3pmQ==", 0, null, new Guid("3df6c47a-9446-40a9-a8d1-6c4321ae1e8c"), "humpty_fore" });

            migrationBuilder.InsertData(
                table: "UsersToRoles",
                columns: new[] { "AppUserId", "AppUserRoleId", "UsersToRolesId" },
                values: new object[] { 1, 3, 3 });

            migrationBuilder.InsertData(
                table: "UsersToRoles",
                columns: new[] { "AppUserId", "AppUserRoleId", "UsersToRolesId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UsersToRoles",
                columns: new[] { "AppUserId", "AppUserRoleId", "UsersToRolesId" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoles_AppUserRoleId",
                table: "UsersToRoles",
                column: "AppUserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersToRoles");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "AppUserRoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "AppUserRoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "AppUserRoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AppUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId");
        }
    }
}
