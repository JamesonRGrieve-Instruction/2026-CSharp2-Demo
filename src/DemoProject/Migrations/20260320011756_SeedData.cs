using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -2, "Mitsubishi" },
                    { -1, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "model",
                columns: new[] { "id", "manufacturer_id", "name" },
                values: new object[,]
                {
                    { -4, -2, "Eclipse" },
                    { -3, -2, "3000GT" },
                    { -2, -1, "Soarer" },
                    { -1, -1, "Supra" }
                });

            migrationBuilder.InsertData(
                table: "vehicle",
                columns: new[] { "vin", "colour", "model_id", "model_year" },
                values: new object[,]
                {
                    { "VIN00000000000001", "Red", -1, 1998 },
                    { "VIN00000000000002", "Black", -2, 1995 },
                    { "VIN00000000000003", "White", -3, 1999 },
                    { "VIN00000000000004", "Blue", -4, 2001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000001");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000002");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000003");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000004");

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "model",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "manufacturer",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
