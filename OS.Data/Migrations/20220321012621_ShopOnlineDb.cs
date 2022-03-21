using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.Data.Migrations
{
    public partial class ShopOnlineDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Customer_CustomerId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Employee_EmployeeId",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Bill",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Bill",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BillId",
                table: "Product",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Customer_CustomerId",
                table: "Bill",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Employee_EmployeeId",
                table: "Bill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Bill_BillId",
                table: "Product",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Customer_CustomerId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Employee_EmployeeId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Bill_BillId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BillId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Customer_CustomerId",
                table: "Bill",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Employee_EmployeeId",
                table: "Bill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
