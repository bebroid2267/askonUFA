using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askonUFA.Migrations
{
    /// <inheritdoc />
    public partial class Ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_ObjectId",
                table: "Attributes");

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

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Links",
                newName: "parentId");

            migrationBuilder.RenameColumn(
                name: "ChildId",
                table: "Links",
                newName: "childId");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Attributes",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attributes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "Attributes",
                newName: "objectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Objects_objectId",
                table: "Attributes",
                column: "objectId",
                principalTable: "Objects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_objectId",
                table: "Attributes");

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

            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "Links",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "childId",
                table: "Links",
                newName: "ChildId");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Attributes",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Attributes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "objectId",
                table: "Attributes",
                newName: "ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Objects_ObjectId",
                table: "Attributes",
                column: "ObjectId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
