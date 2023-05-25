using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesManager.Migrations
{
    /// <inheritdoc />
    public partial class batch_papers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Papers");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Papers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Papers");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Papers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
