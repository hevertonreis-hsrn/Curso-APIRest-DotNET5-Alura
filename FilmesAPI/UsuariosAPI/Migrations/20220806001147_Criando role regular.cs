using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "281523db-8151-465d-8dfc-3326bce99a2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "446b8c89-5cc5-4f90-acc4-c27585d00339", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2108f5c6-d23a-4961-938e-cdf569e7f97e", "AQAAAAEAACcQAAAAEAtmmAZDBtRi8XcviC5R7wjYSvQX93T4nIAWczAf0/PahwfrYDnzFbC09x0VvUYtvg==", "f156b94f-368d-4b10-8f71-ddec93b58b0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "4c677de3-6493-466b-9c04-4542f5d00edc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "882a4569-24ac-4b37-9c74-4c2ac28381d7", "AQAAAAEAACcQAAAAEGI2nxGZxNgPE63QDA9Ce3JBukZl50gSMtiVqkcRpRajbw7PrkeUYnAvmK6nPwWaiA==", "5113da80-3acd-40f4-8216-753e26df4849" });
        }
    }
}
