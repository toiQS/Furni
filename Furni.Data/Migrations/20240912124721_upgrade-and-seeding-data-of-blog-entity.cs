using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.Data.Migrations
{
    /// <inheritdoc />
    public partial class upgradeandseedingdataofblogentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL Image",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B1",
                columns: new[] { "Create At", "URL Image", "Update At" },
                values: new object[] { new DateTime(2024, 8, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9928), "images/blogs/b1.png", new DateTime(2024, 9, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B2",
                columns: new[] { "Create At", "URL Image", "Update At" },
                values: new object[] { new DateTime(2024, 7, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9948), "images/blogs/b1.png", new DateTime(2024, 9, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9949) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B3",
                columns: new[] { "Create At", "URL Image", "Update At" },
                values: new object[] { new DateTime(2024, 6, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9950), "images/blogs/b1.png", new DateTime(2024, 9, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9951) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B4",
                columns: new[] { "Create At", "URL Image", "Update At" },
                values: new object[] { new DateTime(2024, 5, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9952), "images/blogs/b1.png", new DateTime(2024, 9, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B5",
                columns: new[] { "Create At", "URL Image", "Update At" },
                values: new object[] { new DateTime(2024, 4, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9954), "images/blogs/b1.png", new DateTime(2024, 9, 12, 19, 47, 20, 670, DateTimeKind.Local).AddTicks(9955) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL Image",
                table: "Blog");

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B1",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 8, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 9, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B2",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7051), new DateTime(2024, 9, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7051) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B3",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 6, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7052), new DateTime(2024, 9, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7053) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B4",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 5, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7054), new DateTime(2024, 9, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B5",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 4, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7056), new DateTime(2024, 9, 10, 22, 56, 24, 121, DateTimeKind.Local).AddTicks(7056) });
        }
    }
}
