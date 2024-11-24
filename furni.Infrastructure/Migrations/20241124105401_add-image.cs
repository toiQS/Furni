using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace furni.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blog");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Size",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ProductVariant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailId",
                table: "ProductVariant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailId",
                table: "Blog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_ProductVariant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "ProductVariant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ThumbnailId",
                table: "ProductVariant",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ThumbnailId",
                table: "Product",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_ThumbnailId",
                table: "Blog",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_VariantId",
                table: "Image",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Image_ThumbnailId",
                table: "Blog",
                column: "ThumbnailId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Image_ThumbnailId",
                table: "Product",
                column: "ThumbnailId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Image_ThumbnailId",
                table: "ProductVariant",
                column: "ThumbnailId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Image_ThumbnailId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Image_ThumbnailId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Image_ThumbnailId",
                table: "ProductVariant");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_ThumbnailId",
                table: "ProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_Product_ThumbnailId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Blog_ThumbnailId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Blog");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Size",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
