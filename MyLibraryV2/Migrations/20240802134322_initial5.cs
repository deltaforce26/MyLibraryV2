using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibraryV2.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookSetId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolumeNum",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShelfId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookSetId",
                table: "Book",
                column: "BookSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookSet_BookSetId",
                table: "Book",
                column: "BookSetId",
                principalTable: "BookSet",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookSet_BookSetId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookSet");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookSetId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookSetId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "VolumeNum",
                table: "Book");
        }
    }
}
