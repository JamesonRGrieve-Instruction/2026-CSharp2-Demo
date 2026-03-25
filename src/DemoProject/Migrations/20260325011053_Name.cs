using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "example_parent",
                type: "TEXT",
                nullable: false,
                defaultValue: "Temp");

            migrationBuilder.UpdateData(
                table: "example_parent",
                keyColumn: "id",
                keyValue: -1,
                column: "name",
                value: "Temp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "example_parent");
        }
    }
}
