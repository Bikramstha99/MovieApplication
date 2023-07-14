using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "MovieModels",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseDate",
                table: "MovieModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "MovieModels");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "MovieModels",
                newName: "Category");
        }
    }
}
