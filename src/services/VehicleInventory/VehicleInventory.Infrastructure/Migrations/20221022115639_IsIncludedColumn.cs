using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInventory.Infrastructure.Migrations
{
    public partial class IsIncludedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncluded",
                table: "CarItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncluded",
                table: "CarItems");
        }
    }
}
