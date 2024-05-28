using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askonUFA.Migrations
{
    /// <inheritdoc />
    public partial class A : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Objects",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "product",
                table: "Objects",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Objects",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Objects",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "Objects",
                newName: "product");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Objects",
                newName: "id");
        }
    }
}
