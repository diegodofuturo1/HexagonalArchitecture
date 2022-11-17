using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlAdapter.Migrations
{
    public partial class AddRoomPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price_Value",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "Rooms");
        }
    }
}
