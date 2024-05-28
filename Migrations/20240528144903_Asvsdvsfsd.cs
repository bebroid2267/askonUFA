using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askonUFA.Migrations
{
    /// <inheritdoc />
    public partial class Asvsdvsfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "Links",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "childId",
                table: "Links",
                newName: "ChildId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Attributes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "objectId",
                table: "Attributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "ObjectsId",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "objectId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ChildId",
                table: "Links",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ParentId",
                table: "Links",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ObjectsId",
                table: "Attributes",
                column: "ObjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Objects_ObjectsId",
                table: "Attributes",
                column: "ObjectsId",
                principalTable: "Objects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Objects_ChildId",
                table: "Links",
                column: "ChildId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Objects_ParentId",
                table: "Links",
                column: "ParentId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_ObjectsId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Objects_ChildId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Objects_ParentId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ChildId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ParentId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_ObjectsId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "ObjectsId",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Links",
                newName: "parentId");

            migrationBuilder.RenameColumn(
                name: "ChildId",
                table: "Links",
                newName: "childId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Attributes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "objectId",
                table: "Attributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                columns: new[] { "objectId", "name" });
        }
    }
}
