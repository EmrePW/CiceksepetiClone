using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CiceksepetiApp.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d8d1d8a-6c21-4fdb-80eb-797637489609");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16343e77-f505-4ff1-bcf0-833f799bd5e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5fe5e3b-1b64-410b-b089-74cc198bed53");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "189c1866-44da-41e8-af3f-862dde6ca486", "11c0ae44-e7e3-4c08-8f66-3af0cb2edff5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8de3f6d3-83b0-4af0-9117-87c80dda1210", "4d6cf91e-2bef-4650-a86e-6caca9b19778", "Corporate", "CORPORATE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9aa58c4-0ff4-4d31-a51f-79f44bd2f270", "30529fcc-42ae-4325-adf1-e0892f302c50", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "189c1866-44da-41e8-af3f-862dde6ca486");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8de3f6d3-83b0-4af0-9117-87c80dda1210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9aa58c4-0ff4-4d31-a51f-79f44bd2f270");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d8d1d8a-6c21-4fdb-80eb-797637489609", "447e75a1-2059-45cf-a56c-3f20f32333b3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16343e77-f505-4ff1-bcf0-833f799bd5e1", "a7860be5-cde7-4b9e-bab4-24a70e90cf93", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5fe5e3b-1b64-410b-b089-74cc198bed53", "aba1baa4-706d-4537-ae5b-b702e261e714", "Corporate", "CORPORATE" });
        }
    }
}
