using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.Data.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "CartProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_BillId",
                table: "CartProduct",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Bill_BillId",
                table: "CartProduct",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Bill_BillId",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_BillId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "CartProduct");
        }
    }
}
