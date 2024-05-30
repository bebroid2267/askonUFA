using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askonUFA.Migrations
{
    /// <inheritdoc />
    public partial class beb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_ObjectsId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_objectId",
                table: "Attributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_ObjectsId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "ObjectsId",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "objectId",
                table: "Attributes",
                newName: "ObjectId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Attributes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TreeItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectsId = table.Column<int>(type: "int", nullable: true),
                    ObjectsId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeItem_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreeItem_Objects_ObjectsId1",
                        column: x => x.ObjectsId1,
                        principalTable: "Objects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ObjectId",
                table: "Attributes",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeItem_ObjectsId",
                table: "TreeItem",
                column: "ObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeItem_ObjectsId1",
                table: "TreeItem",
                column: "ObjectsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Objects_ObjectId",
                table: "Attributes",
                column: "ObjectId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_TreeItem_Id",
                table: "Objects",
                column: "Id",
                principalTable: "TreeItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Objects_ObjectId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_TreeItem_Id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "TreeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_ObjectId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "Attributes",
                newName: "objectId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ObjectsId",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "objectId");

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
                name: "FK_Attributes_Objects_objectId",
                table: "Attributes",
                column: "objectId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
