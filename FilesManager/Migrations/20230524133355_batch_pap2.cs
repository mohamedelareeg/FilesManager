using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesManager.Migrations
{
    /// <inheritdoc />
    public partial class batch_pap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Batches");
        }
    }
}
