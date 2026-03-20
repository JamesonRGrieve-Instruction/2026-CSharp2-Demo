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
                table: "classroom",
                columns: new[] { "id", "room_number" },
                values: new object[] { -1, 101 });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "class_id", "first_name", "last_name", "middle_name" },
                values: new object[] { -1, -1, "John", "Doe", "Bob" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "classroom",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
