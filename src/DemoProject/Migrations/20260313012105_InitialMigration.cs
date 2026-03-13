using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "example_parent",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_example_parent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "example_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parent_id = table.Column<int>(type: "INTEGER", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_example_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_$Student_ClassRoom",
                        column: x => x.parent_id,
                        principalTable: "example_parent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "example_parent",
                columns: new[] { "id", "room_number" },
                values: new object[,]
                {
                    { -2, 102 },
                    { -1, 101 }
                });

            migrationBuilder.InsertData(
                table: "example_table",
                columns: new[] { "id", "parent_id", "first_name", "last_name" },
                values: new object[,]
                {
                    { -6, -2, "C", "Student" },
                    { -5, -2, "B", "Student" },
                    { -4, -2, "A", "Student" },
                    { -3, -1, "Test", "Student" },
                    { -2, -1, "Jane", "Doe" },
                    { -1, -1, "John", "Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_example_table_parent_id",
                table: "example_table",
                column: "parent_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "example_table");

            migrationBuilder.DropTable(
                name: "example_parent");
        }
    }
}
