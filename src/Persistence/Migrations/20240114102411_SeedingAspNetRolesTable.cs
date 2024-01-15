using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAspNetRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3659f040-51a9-496a-958d-7030a439012e", null, "TeamLead", "TEAMLEAD" },
                    { "60024229-fb65-490d-abfd-f1369a56f952", null, "Admin", "ADMIN" },
                    { "6e875cce-3fc3-4ad3-87f5-9672ddeaa099", null, "RegularEmployee", "REGULAREMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3659f040-51a9-496a-958d-7030a439012e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60024229-fb65-490d-abfd-f1369a56f952");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e875cce-3fc3-4ad3-87f5-9672ddeaa099");
        }
    }
}
