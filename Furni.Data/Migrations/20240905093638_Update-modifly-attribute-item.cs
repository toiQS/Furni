using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatemodiflyattributeitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "Item",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Item");
        }
    }
}
