using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.Data.Migrations
{
    public partial class OnlineShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProduct_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "EmployeeId", "Type" },
                values: new object[,]
                {
                    { 1, null, "Cà phê" },
                    { 2, null, "Trà" },
                    { 3, null, "Sinh tố" },
                    { 4, null, "Nước ép" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "trunghuy0501@gmail.com", "Lê Trung Huy", "0903796984" },
                    { 2, "ngothithuytien1603@gmail.com", "Ngô Thị Thủy Tiên", "0383860994" },
                    { 3, "myquynn1703@gmail.com", "Lê Mỹ Quỳnh", "0234567891" },
                    { 4, "nhathanh@gmail.com", "Tiêu Nhã Thanh", "0345678912" },
                    { 5, "quyntram@gmail.com", "Vũ Ngọc Quỳnh Trâm", "0456789123" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BillId", "CategoryId", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 1, "images/1.jpg", "Cà phê sữa", 35000 },
                    { 18, null, 4, "images/18.jpg", "Nước ép bưởi", 40000 },
                    { 17, null, 4, "images/17.jpg", "Nước ép táo", 40000 },
                    { 16, null, 4, "images/16.jpg", "Nước ép dâu ", 40000 },
                    { 15, null, 3, "images/15.jpg", "Sinh tố xoài", 35000 },
                    { 14, null, 3, "images/14.jpg", "Sinh tố dưa hấu", 35000 },
                    { 13, null, 3, "images/13.jpg", "Sinh tố chuối", 35000 },
                    { 12, null, 3, "images/12.jpg", "Sinh tố bơ", 35000 },
                    { 11, null, 3, "images/11.jpg", "Sinh tố dâu", 35000 },
                    { 10, null, 2, "images/10.jpg", "Trà hoa hồng", 40000 },
                    { 9, null, 2, "images/9.jpg", "Trà đen", 40000 },
                    { 8, null, 2, "images/8.jpg", "Trà xanh bạc hà", 40000 },
                    { 7, null, 2, "images/7.jpg", "Trà Earl Grey", 40000 },
                    { 6, null, 2, "images/6.jpg", "Trà hoa cúc", 40000 },
                    { 5, null, 1, "images/5.jpg", "Latte", 50000 },
                    { 4, null, 1, "images/4.jpg", "Espresso", 55000 },
                    { 3, null, 1, "images/3.jpg", "Cappuchino", 50000 },
                    { 2, null, 1, "images/2.jpg", "Cà phê Americano", 50000 },
                    { 19, null, 4, "images/19.jpg", "Nước ép nho", 40000 },
                    { 20, null, 4, "images/20.jpg", "Nước ép lựu", 40000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CustomerId",
                table: "Bill",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_EmployeeId",
                table: "Bill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CustomerId",
                table: "CartProduct",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EmployeeId",
                table: "Category",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BillId",
                table: "Product",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
