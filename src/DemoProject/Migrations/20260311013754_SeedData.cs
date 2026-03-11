using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "example_table",
                column: "id",
                values: new object[]
                {
                    -3,
                    -2,
                    -1
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
