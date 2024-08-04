using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibraryV2.Migrations
{
    /// <inheritdoc />
    public partial class initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hight",
                table: "BookSet");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "BookSet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hight",
                table: "BookSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "BookSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
