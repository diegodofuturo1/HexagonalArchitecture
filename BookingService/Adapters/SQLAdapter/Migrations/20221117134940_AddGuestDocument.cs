using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlAdapter.Migrations
{
    public partial class AddGuestDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document_DocumentId",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Document_DocumentType",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document_DocumentId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Document_DocumentType",
                table: "Guests");
        }
    }
}
