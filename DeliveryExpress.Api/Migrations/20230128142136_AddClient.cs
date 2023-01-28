using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 11, 21, 36, 114, DateTimeKind.Local).AddTicks(1508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 4, 15, 754, DateTimeKind.Local).AddTicks(6590));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 26, 23, 4, 15, 754, DateTimeKind.Local).AddTicks(6590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 11, 21, 36, 114, DateTimeKind.Local).AddTicks(1508));
        }
    }
}
