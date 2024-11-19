using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace furni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateentity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "DeliveryInformation");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Update_At",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "URL_Image",
                table: "Users",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "ProductVariant",
                newName: "URLImages");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Order",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Category",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Brand",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Create_At",
                table: "Blog",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Blog_Name",
                table: "Blog",
                newName: "BlogName");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blog",
                newName: "IsPublic");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Address",
                newName: "SpecificAddress");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShippingMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethodId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeteled",
                table: "Blog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingMethodId",
                table: "Order",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingMethod_ShippingMethodId",
                table: "Order",
                column: "ShippingMethodId",
                principalTable: "ShippingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingMethod_ShippingMethodId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_Order_AddressId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "IsDeteled",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Users",
                newName: "URL_Image");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Full_Name");

            migrationBuilder.RenameColumn(
                name: "URLImages",
                table: "ProductVariant",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Order",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Category",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Brand",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Blog",
                newName: "Create_At");

            migrationBuilder.RenameColumn(
                name: "BlogName",
                table: "Blog",
                newName: "Blog_Name");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Blog",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "SpecificAddress",
                table: "Address",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<DateTime>(
                name: "Update_At",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryInformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShippingMethodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryInformation_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryInformation_ShippingMethod_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethod",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductVariantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_ProductVariant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_CartId",
                table: "CartDetail",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductVariantId",
                table: "CartDetail",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInformation_OrderId",
                table: "DeliveryInformation",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInformation_ShippingMethodId",
                table: "DeliveryInformation",
                column: "ShippingMethodId");
        }
    }
}
