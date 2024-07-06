using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_sms.Migrations
{
    /// <inheritdoc />
    public partial class regis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 7, 4, 5, 47, 21, 585, DateTimeKind.Utc).AddTicks(7240), "LandenPhD@gmail.com", "220.163.1527 x2132", "Eleanora Kunze" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 7, 4, 5, 47, 21, 585, DateTimeKind.Utc).AddTicks(9598), "JustonI@gmail.com", "243-338-9771", "Kristoffer Gleichner" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 7, 4, 5, 47, 21, 586, DateTimeKind.Utc).AddTicks(2482), "MarleyV@gmail.com", "020.746.8050 x374", "Candace Mertz PhD" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 7, 4, 5, 47, 21, 586, DateTimeKind.Utc).AddTicks(4552), "MarinaDDS@gmail.com", "496.135.9707 x25931", "Mrs. Adeline Nova Robel PhD" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 7, 4, 5, 47, 21, 586, DateTimeKind.Utc).AddTicks(9174), "MarjoryII@gmail.com", "400.828.0990 x069", "Genesis Koepp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 6, 510, DateTimeKind.Utc).AddTicks(6310), "BrandtDVM@gmail.com", "1-573-113-3670 x550", "Clementine Stiedemann" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(377), "JulianneDVM@gmail.com", "296-244-4379", "Cora Von" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(2492), "KianaDVM@gmail.com", "691.701.8685", "Virgil Imelda Mann V" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(5863), "VivianV@gmail.com", "278.148.0361 x0050", "Casimir Stoltenberg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "Phone_Number", "User_name" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(7556), "SandyDVM@gmail.com", "261.741.8024", "Fred Pacocha" });
        }
    }
}
