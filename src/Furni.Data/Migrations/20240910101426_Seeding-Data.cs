using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Furni.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Cart Id", "Status", "User Id" },
                values: new object[,]
                {
                    { "C1", true, "M1" },
                    { "C2", true, "M2" },
                    { "C3", true, "M3" },
                    { "C4", true, "M4" },
                    { "C5", true, "M5" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Member Id", "First Name", "Full Name", "IsDeleted", "Last Name", "Middle Name", "Position", "Summary", "URL Image" },
                values: new object[,]
                {
                    { "M1", "John", "John A Doe", false, "Doe", "A", "Admin", "Administrator", "/images/johndoe.jpg" },
                    { "M2", "Jane", "Jane B Doe", false, "Doe", "B", "User", "Regular user", "/images/janedoe.jpg" },
                    { "M3", "Alice", "Alice C Johnson", false, "Johnson", "C", "Designer", "Interior Designer", "/images/alice.jpg" },
                    { "M4", "Bob", "Bob D Smith", false, "Smith", "D", "Sales", "Sales Manager", "/images/bob.jpg" },
                    { "M5", "Eve", "Eve E Taylor", false, "Taylor", "E", "Marketing", "Marketing Specialist", "/images/eve.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Product Id", "Is Active", "Price", "Product Name", "URL Image" },
                values: new object[,]
                {
                    { "P1", true, 499.99f, "Sofa", "/images/sofa.jpg" },
                    { "P2", true, 79.99f, "Chair", "/images/chair.jpg" },
                    { "P3", true, 199.99f, "Table", "/images/table.jpg" },
                    { "P4", true, 29.99f, "Lamp", "/images/lamp.jpg" },
                    { "P5", true, 149.99f, "Bookshelf", "/images/bookshelf.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Blog Id", "Blog Name", "Create At", "Update At", "User Id Created" },
                values: new object[,]
                {
                    { "B1", "Furniture Tips", new DateTime(2024, 8, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4875), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4893), "M1" },
                    { "B2", "Interior Design Ideas", new DateTime(2024, 7, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4895), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4896), "M2" },
                    { "B3", "Latest Trends in Furniture", new DateTime(2024, 6, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4897), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4897), "M3" },
                    { "B4", "Home Decor Essentials", new DateTime(2024, 5, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4899), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4899), "M4" },
                    { "B5", "Choosing the Right Furniture", new DateTime(2024, 4, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4900), new DateTime(2024, 9, 10, 17, 14, 26, 565, DateTimeKind.Local).AddTicks(4901), "M5" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Item Id", "Cart Id", "Price", "Product Id", "Quantity", "Total" },
                values: new object[,]
                {
                    { "I1", "C1", 499.99f, "P1", 1, 499.99f },
                    { "I2", "C2", 79.99f, "P2", 2, 159.98f },
                    { "I3", "C3", 199.99f, "P3", 1, 199.99f },
                    { "I4", "C4", 29.99f, "P4", 3, 89.97f },
                    { "I5", "C5", 149.99f, "P5", 1, 149.99f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B1");

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B2");

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B3");

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B4");

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Blog Id",
                keyValue: "B5");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Item Id",
                keyValue: "I1");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Item Id",
                keyValue: "I2");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Item Id",
                keyValue: "I3");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Item Id",
                keyValue: "I4");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Item Id",
                keyValue: "I5");

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Cart Id",
                keyValue: "C1");

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Cart Id",
                keyValue: "C2");

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Cart Id",
                keyValue: "C3");

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Cart Id",
                keyValue: "C4");

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Cart Id",
                keyValue: "C5");

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Member Id",
                keyValue: "M1");

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Member Id",
                keyValue: "M2");

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Member Id",
                keyValue: "M3");

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Member Id",
                keyValue: "M4");

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Member Id",
                keyValue: "M5");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product Id",
                keyValue: "P1");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product Id",
                keyValue: "P2");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product Id",
                keyValue: "P3");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product Id",
                keyValue: "P4");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product Id",
                keyValue: "P5");
        }
    }
}
