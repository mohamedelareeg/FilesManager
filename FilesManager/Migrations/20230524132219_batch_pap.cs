using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesManager.Migrations
{
    /// <inheritdoc />
    public partial class batch_pap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BatchesId",
                table: "Documents",
                newName: "BatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "Documents",
                newName: "BatchesId");
        }
    }
}
