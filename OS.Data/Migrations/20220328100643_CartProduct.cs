using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.Data.Migrations
{
    public partial class CartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Customer_CustomerId",
                table: "CartProduct");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CartProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Customer_CustomerId",
                table: "CartProduct",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Customer_CustomerId",
                table: "CartProduct");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CartProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Customer_CustomerId",
                table: "CartProduct",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
