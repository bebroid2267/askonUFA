using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askonUFA.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_TreeItem_Id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "TreeItem");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
                name: "IX_TreeItem_ObjectsId",
                table: "TreeItem",
                column: "ObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeItem_ObjectsId1",
                table: "TreeItem",
                column: "ObjectsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_TreeItem_Id",
                table: "Objects",
                column: "Id",
                principalTable: "TreeItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
