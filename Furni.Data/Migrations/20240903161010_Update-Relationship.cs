using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cart Id",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "User Id Created",
                table: "Blog",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Cart Id",
                table: "Item",
                column: "Cart Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_User Id Created",
                table: "Blog",
                column: "User Id Created");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Member_User Id Created",
                table: "Blog",
                column: "User Id Created",
                principalTable: "Member",
                principalColumn: "Member Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cart_Cart Id",
                table: "Item",
                column: "Cart Id",
                principalTable: "Cart",
                principalColumn: "Cart Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Member_User Id Created",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cart_Cart Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Cart Id",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Blog_User Id Created",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Cart Id",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "User Id Created",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
