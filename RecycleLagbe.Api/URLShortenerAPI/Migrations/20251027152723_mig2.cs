using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortenerAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortenedURL",
                table: "URL_Items",
                newName: "ShortURLCode");

            migrationBuilder.UpdateData(
                table: "URL_Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ShortURLCode" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A1XS23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortURLCode",
                table: "URL_Items",
                newName: "ShortenedURL");

            migrationBuilder.UpdateData(
                table: "URL_Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ShortenedURL" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.tinyurl.com/A1XS23" });
        }
    }
}
