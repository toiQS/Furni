using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateidentityversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B1",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 8, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4875), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B2",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 7, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4895), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B3",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 6, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4897), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4897) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B4",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 5, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4899), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4899) });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B5",
                columns: new[] { "Create At", "Update At" },
                values: new object[] { new DateTime(2024, 4, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4900), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4901) });
        }
    }
}
