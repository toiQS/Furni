using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace furni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeforcorrectdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posta",
                table: "DeliveryInformation"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInformation_Order_OrderId",
                table: "DeliveryInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Order_CouponId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInformation_OrderId",
                table: "DeliveryInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "CartDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "URL_Image",
                table: "Users",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "Middle_Name",
                table: "Users",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "URL_Image",
                table: "Product",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "Product_Name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "Product",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Street_Address",
                table: "DeliveryInformation",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "DeliveryInformation",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "DeliveryInformation",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Company_Name",
                table: "DeliveryInformation",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Address_Detail",
                table: "DeliveryInformation",
                newName: "AddressDetail");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "DeliveryInformation",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Update_At",
                table: "Blog",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "URL_Image",
                table: "Blog",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "Blog",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Create_At",
                table: "Blog",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Blog_Name",
                table: "Blog",
                newName: "BlogName");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryInformationId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WarehouseId",
                table: "Product",
                column: "WarehouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CouponId",
                table: "Order",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryInformationId",
                table: "Order",
                column: "DeliveryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInformation_UserId",
                table: "DeliveryInformation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInformation_Users_UserId",
                table: "DeliveryInformation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryInformation_DeliveryInformationId",
                table: "Order",
                column: "DeliveryInformationId",
                principalTable: "DeliveryInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Warehouse_WarehouseId",
                table: "Product",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInformation_Users_UserId",
                table: "DeliveryInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryInformation_DeliveryInformationId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Warehouse_WarehouseId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_WarehouseId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_CouponId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryInformationId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInformation_UserId",
                table: "DeliveryInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeliveryInformationId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Stocks");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Users",
                newName: "URL_Image");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Users",
                newName: "Middle_Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Full_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Product",
                newName: "URL_Image");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Product_Name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Product",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "DeliveryInformation",
                newName: "Street_Address");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "DeliveryInformation",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "DeliveryInformation",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "DeliveryInformation",
                newName: "Company_Name");

            migrationBuilder.RenameColumn(
                name: "AddressDetail",
                table: "DeliveryInformation",
                newName: "Address_Detail");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DeliveryInformation",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Blog",
                newName: "Update_At");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Blog",
                newName: "URL_Image");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blog",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Blog",
                newName: "Create_At");

            migrationBuilder.RenameColumn(
                name: "BlogName",
                table: "Blog",
                newName: "Blog_Name");

            migrationBuilder.AddColumn<string>(
                name: "OrderDetailId",
                table: "CartDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CouponId",
                table: "Order",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInformation_OrderId",
                table: "DeliveryInformation",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInformation_Order_OrderId",
                table: "DeliveryInformation",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
