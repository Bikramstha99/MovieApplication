using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "MovieModels");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "MovieModels",
                type: "int",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "MovieModels");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseDate",
                table: "MovieModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
