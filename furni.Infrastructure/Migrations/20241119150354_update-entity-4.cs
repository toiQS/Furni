using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace furni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateentity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Users_UserId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductVariant_ProductVariantId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Size_SizeId",
                table: "ProductVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "BlogName",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "TopicName",
                table: "Topic",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Review",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Review",
                newName: "IX_Review_AppUserId");

            migrationBuilder.RenameColumn(
                name: "URLImages",
                table: "ProductVariant",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Product",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Product",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "OrderDetail",
                newName: "VariantSizeId");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "OrderDetail",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductVariantId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_VariantSizeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Order",
                newName: "SubTotal");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_AppUserId");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Brand",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserIdCreated",
                table: "Blog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "URL_Image",
                table: "Blog",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Address",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "Address",
                newName: "IX_Address_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SizeId",
                table: "ProductVariant",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Blog",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VariantSize",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VariantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SizeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantSize_ProductVariant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "ProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantSize_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AppUserId",
                table: "Blog",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantSize_SizeId",
                table: "VariantSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantSize_VariantId",
                table: "VariantSize",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_AppUserId",
                table: "Address",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Users_AppUserId",
                table: "Blog",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_AppUserId",
                table: "Order",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_VariantSize_VariantSizeId",
                table: "OrderDetail",
                column: "VariantSizeId",
                principalTable: "VariantSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Size_SizeId",
                table: "ProductVariant",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_AppUserId",
                table: "Review",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_AppUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Users_AppUserId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_AppUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_VariantSize_VariantSizeId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Size_SizeId",
                table: "ProductVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_AppUserId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "VariantSize");

            migrationBuilder.DropIndex(
                name: "IX_Blog_AppUserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "JoinTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Topic",
                newName: "TopicName");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Review",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_AppUserId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "ProductVariant",
                newName: "URLImages");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Product",
                newName: "URLImage");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Product",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "VariantSizeId",
                table: "OrderDetail",
                newName: "ProductVariantId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetail",
                newName: "ProductPrice");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_VariantSizeId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductVariantId");

            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "Order",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AppUserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brand",
                newName: "BrandName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Blog",
                newName: "UserIdCreated");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Blog",
                newName: "URL_Image");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Address",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_AppUserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SizeId",
                table: "ProductVariant",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "ProductVariant",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "BlogName",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Blog",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Users_UserId",
                table: "Blog",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductVariant_ProductVariantId",
                table: "OrderDetail",
                column: "ProductVariantId",
                principalTable: "ProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Size_SizeId",
                table: "ProductVariant",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
