using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parent_id",
                table: "example_table",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "example_parent",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_example_parent", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "example_parent",
                column: "id",
                value: -1);

            migrationBuilder.UpdateData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -3,
                column: "parent_id",
                value: -1);

            migrationBuilder.UpdateData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -2,
                column: "parent_id",
                value: -1);

            migrationBuilder.UpdateData(
                table: "example_table",
                keyColumn: "id",
                keyValue: -1,
                column: "parent_id",
                value: -1);

            migrationBuilder.CreateIndex(
                name: "IX_example_table_parent_id",
                table: "example_table",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_$ExampleTable_ExampleParent",
                table: "example_table",
                column: "parent_id",
                principalTable: "example_parent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_$ExampleTable_ExampleParent",
                table: "example_table");

            migrationBuilder.DropTable(
                name: "example_parent");

            migrationBuilder.DropIndex(
                name: "IX_example_table_parent_id",
                table: "example_table");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "example_table");
        }
    }
}
