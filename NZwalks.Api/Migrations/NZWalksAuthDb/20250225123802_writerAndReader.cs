using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZwalks.Api.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class writerAndReader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c095b72-07f6-4b46-8a85-081f09fca629", "2c095b72-07f6-4b46-8a85-081f09fca629", "Reader", "READER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c095b72-07f6-4b46-8a85-081f09fca629");
        }
    }
}
