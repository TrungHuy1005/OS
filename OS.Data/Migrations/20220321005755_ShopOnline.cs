using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.Data.Migrations
{
    public partial class ShopOnline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Product",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "Detail");
        }
    }
}
