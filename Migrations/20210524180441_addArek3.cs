using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektCRUD.Migrations
{
    public partial class addArek3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemQuantity",
                table: "Items",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Items",
                newName: "ItemQuantity");
        }
    }
}
