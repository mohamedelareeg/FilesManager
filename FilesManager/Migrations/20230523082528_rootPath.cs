using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesManager.Migrations
{
    /// <inheritdoc />
    public partial class rootPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RootPath",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RootPath",
                table: "Files");
        }
    }
}
