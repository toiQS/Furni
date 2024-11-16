using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace furni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Coupon_CouponId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropIndex(
                name: "IX_Order_CouponId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Middle_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Detail",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "Company_Name",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "BrandDescription",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BrandEmail",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BrandPhone",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "Street_Address",
                table: "DeliveryInformation",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "DeliveryInformation",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Posta",
                table: "DeliveryInformation",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "OrderNote",
                table: "DeliveryInformation",
                newName: "OrderDescription");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "Blog",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductId",
                table: "Warehouse",
                newName: "IX_Warehouse_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "CouponId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShippingFee",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethodId",
                table: "DeliveryInformation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TopicId",
                table: "Blog",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInformation_ShippingMethodId",
                table: "DeliveryInformation",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_TopicId",
                table: "Blog",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Topic_TopicId",
                table: "Blog",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInformation_ShippingMethod_ShippingMethodId",
                table: "DeliveryInformation",
                column: "ShippingMethodId",
                principalTable: "ShippingMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Product_ProductId",
                table: "Warehouse",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Topic_TopicId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInformation_ShippingMethod_ShippingMethodId",
                table: "DeliveryInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Product_ProductId",
                table: "Warehouse");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ShippingMethod");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInformation_ShippingMethodId",
                table: "DeliveryInformation");

            migrationBuilder.DropIndex(
                name: "IX_Blog_TopicId",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "DeliveryInformation");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Stocks");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "DeliveryInformation",
                newName: "Street_Address");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DeliveryInformation",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "DeliveryInformation",
                newName: "Posta");

            migrationBuilder.RenameColumn(
                name: "OrderDescription",
                table: "DeliveryInformation",
                newName: "OrderNote");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blog",
                newName: "Is_Active");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_ProductId",
                table: "Stocks",
                newName: "IX_Stocks_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Middle_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CouponId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Detail",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Name",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "DeliveryInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandDescription",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandEmail",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandPhone",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    MaxTotalDiscount = table.Column<double>(type: "float", nullable: false),
                    MinRequire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CouponId",
                table: "Order",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Coupon_CouponId",
                table: "Order",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
