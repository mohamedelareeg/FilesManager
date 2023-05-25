using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesManager.Migrations
{
    /// <inheritdoc />
    public partial class change_base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Batches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Papers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Papers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Papers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Papers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Batches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Batches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
