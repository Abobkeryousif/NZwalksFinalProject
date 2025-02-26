using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZwalks.Api.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class writer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e29494c-fda7-4943-81a4-f72a29ebb575");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a67fe12b-2dca-4ae7-8cc4-45a44021352a", "a67fe12b-2dca-4ae7-8cc4-45a44021352a", "Writer", "WRITER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a67fe12b-2dca-4ae7-8cc4-45a44021352a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e29494c-fda7-4943-81a4-f72a29ebb575", "4e29494c-fda7-4943-81a4-f72a29ebb575", "Reader", "READER" });
        }
    }
}
