using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZahInventrizaciya.Migrations
{
    /// <inheritdoc />
    public partial class EditItemProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InventoryNumber",
                table: "Items",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InventoryNumber",
                table: "Items",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
