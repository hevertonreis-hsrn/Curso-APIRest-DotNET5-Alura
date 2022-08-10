using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "f2dfb8a1-c895-4382-8e46-d8efdf9be6b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0d52cccf-eb52-47d0-a67e-a4e9b40c3eec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca7d803e-87d0-452f-b7ed-334ce5e0c0b7", "AQAAAAEAACcQAAAAEB74nmZmqyPf5o/h6pnLk0wE1gzCzInkpalZNUrN0j5QZ30uFFoMAwaJwZA5tZFkXw==", "e6d1be2f-a140-430c-9604-602f95e9597a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "446b8c89-5cc5-4f90-acc4-c27585d00339");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "281523db-8151-465d-8dfc-3326bce99a2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2108f5c6-d23a-4961-938e-cdf569e7f97e", "AQAAAAEAACcQAAAAEAtmmAZDBtRi8XcviC5R7wjYSvQX93T4nIAWczAf0/PahwfrYDnzFbC09x0VvUYtvg==", "f156b94f-368d-4b10-8f71-ddec93b58b0e" });
        }
    }
}
