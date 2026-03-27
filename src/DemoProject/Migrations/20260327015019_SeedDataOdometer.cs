using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataOdometer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000001",
                column: "odometer",
                value: 100);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000002",
                column: "odometer",
                value: 100);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000003",
                column: "odometer",
                value: 100);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000004",
                column: "odometer",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000001",
                column: "odometer",
                value: 0);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000002",
                column: "odometer",
                value: 0);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000003",
                column: "odometer",
                value: 0);

            migrationBuilder.UpdateData(
                table: "vehicle",
                keyColumn: "vin",
                keyValue: "VIN00000000000004",
                column: "odometer",
                value: 0);
        }
    }
}
