using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GranCanariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeddataDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 16, 1, 28, 368, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 16, 1, 28, 368, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 16, 1, 28, 368, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 16, 1, 28, 368, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 16, 1, 28, 368, DateTimeKind.Local).AddTicks(2605));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
