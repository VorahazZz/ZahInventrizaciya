using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZahInventrizaciya.Migrations
{
    /// <inheritdoc />
    public partial class EditItemsAndClassrooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ItemsAndClassrooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ItemsAndClassrooms");
        }
    }
}
